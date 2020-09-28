using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flying_Cow_TMSAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Flying_Cow_TMSAPI.Virtual_Model;
using Microsoft.EntityFrameworkCore;

namespace Flying_Cow_TMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Trace_MController : ControllerBase
    {
        //依赖注入
        public TMSDBContext db;
        public Trace_MController(TMSDBContext db) { this.db = db; }

        /// <summary>
        /// 显示跟踪列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTracePageList")]
        public async Task<GetTracePageList> GetTracePageList(string btime = "", string etime = "", string if_number = "", int pageIndex = 1, int pageSize = 4)
        {
            var list = await (from i in db.Inquiry
                              from e in db.Entrust
                              from c in db.Consignee
                              from o in db.Offer
                              where i.if_Id == e.ifid && c.eid == e.e_Id && o.ciid == i.if_Id
                              select new GetTraceModel
                              {
                                  if_Id=i.if_Id,
                                  //订单号
                                  if_Number = i.if_Number,
                                  //联系人
                                  e_AddPerson = e.e_AddPerson,
                                  //委托方
                                  e_Company = e.e_Company,
                                  //委托人
                                  e_Person = e.e_Person,
                                  //始发地
                                  if_BeginPlace = i.if_BeginPlace,
                                  //目的地
                                  if_EndPlace = i.if_EndPlace,
                                  //车牌
                                  o_Row = o.o_Row,
                                  //运作状态
                                  co_State = c.co_State,
                                  //监控状态
                                  if_OrderTime = i.if_OrderTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                  //计划发车时间
                                  if_PlanBCarTime = i.if_PlanBCarTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                  //实际发车时间
                                  if_BCarTime = i.if_BCarTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                  //预计到达时间
                                  if_PlanArrivalTime = i.if_PlanArrivalTime.ToString("yyyy-MM-dd HH:mm:ss"),

                              }).ToListAsync();

            //实例化
            GetTracePageList data = new GetTracePageList();
            if (!string.IsNullOrEmpty(if_number))
            {
                data.GetTraceModel = list.Where(x => x.if_Number.Contains(if_number)).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
            else if (btime != null)
            {
                data.GetTraceModel = list.Where(x =>  Convert.ToDateTime(x.if_OrderTime)>= Convert.ToDateTime(btime) & Convert.ToDateTime(x.if_OrderTime) <= Convert.ToDateTime(etime)).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
            else
            {
                data.GetTraceModel = list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }


            //总页数
            if (list.Count() % pageSize == 0)
            {
                data.TotalPage = list.Count() / pageSize;
            }
            else
            {
                data.TotalPage = list.Count() / pageSize + 1;
            }

            return data;
        }
        /// <summary>
        /// 详情页
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("XiangQX")]
        public async Task<ActionResult<List<GetTraceModel>>> XiangQX(int Id)
        {
            var list = await (from i in db.Inquiry
                              from e in db.Entrust
                              from c in db.Consignee
                              from o in db.Offer
                              where i.if_Id == e.ifid && c.eid == e.e_Id && o.ciid == i.if_Id
                              where i.if_Id == Id
                              select new GetTraceModel
                              {
                                  //订单号
                                  if_Number = i.if_Number,
                                  //计划发车时间
                                  if_PlanBCarTime = i.if_PlanBCarTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                  //实际发车时间
                                  if_BCarTime = i.if_BCarTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                  //预计到达时间
                                  if_PlanArrivalTime = i.if_PlanArrivalTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                  //始发地
                                  if_BeginPlace = i.if_BeginPlace,
                                  //目的地
                                  if_EndPlace = i.if_EndPlace,
                                  //委托方
                                  e_Company = e.e_Company,
                                  //委托人
                                  e_Person = e.e_Person,
                                  o_Row = o.o_Row,
                                  e_Phone = e.e_Phone,
                                  //收货方
                                  co_Company = c.co_Company,
                                  //收货人
                                  co_Person = c.co_Person,
                                  //联系电话
                                  co_Phone = c.co_Phone,
                                  //收货地址
                                  co_Address = c.co_Address,
                                  //货名
                                  if_Goods = i.if_Goods,
                                  //规格型号
                                  if_Specification = i.if_Specification,
                                  //总包装
                                  if_TotalPackage = i.if_TotalPackage,
                                  //总数量
                                  if_Num = i.if_Num,
                                  //总重量Kg
                                  if_AllWeight = i.if_AllWeight,
                                  //提货联系人
                                  e_AddPerson = e.e_AddPerson,
                                  //联系电话
                                  e_AddPhone = e.e_AddPhone,
                                  //订单备注
                                  if_Remark = i.if_Remark,
                              }).ToListAsync();
            return list;
        }

        /// <summary>
        /// LayUI详情页
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("XiangQ")]
        public async Task<JsonData> XiangQ(int Id)
        {
            JsonData jd = new JsonData();
            var list = await (from i in db.Inquiry
                              from e in db.Entrust
                              from c in db.Consignee
                              from o in db.Offer
                              where i.if_Id == e.ifid && c.eid == e.e_Id && o.ciid == i.if_Id
                              where i.if_Id == Id
                              select new GetTraceModel
                              {
                                  //订单号
                                  if_Number = i.if_Number,
                                  //计划发车时间
                                  if_PlanBCarTime = i.if_PlanBCarTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                  //实际发车时间
                                  if_BCarTime = i.if_BCarTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                  //预计到达时间
                                  if_PlanArrivalTime = i.if_PlanArrivalTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                  //始发地
                                  if_BeginPlace = i.if_BeginPlace,
                                  //目的地
                                  if_EndPlace = i.if_EndPlace,
                                  //委托方
                                  e_Company = e.e_Company,
                                  //委托人
                                  e_Person = e.e_Person,
                                  o_Row=o.o_Row,
                                  e_Phone=e.e_Phone,
                                  //收货方
                                  co_Company = c.co_Company,
                                  //收货人
                                  co_Person = c.co_Person,
                                  //联系电话
                                  co_Phone = c.co_Phone,
                                  //收货地址
                                  co_Address = c.co_Address,
                                  //货名
                                  if_Goods = i.if_Goods,
                                  //规格型号
                                  if_Specification = i.if_Specification,
                                  //总包装
                                  if_TotalPackage = i.if_TotalPackage,
                                  //总数量
                                  if_Num = i.if_Num,
                                  //总重量Kg
                                  if_AllWeight = i.if_AllWeight,
                                  //提货联系人
                                  e_AddPerson = e.e_AddPerson,
                                  //联系电话
                                  e_AddPhone = e.e_AddPhone,
                                  //订单备注
                                  if_Remark = i.if_Remark,
                              }).ToListAsync();
            jd.data = list.ToList();
            jd.code = 0;
            jd.count = list.Count();
            jd.msg = "";
            return  jd;
        }
        /// <summary>
        /// 在途跟踪途经站点
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("RouteAdd")]
        public async Task<ActionResult<List<Route>>> RouteAdd(int Id)
        {
            var list = await (from r in db.Route
                             where r.ifid == Id
                             select r).ToListAsync();
            return list;
        }

        /// <summary>
        /// 获取图片
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetImg")]
        public  List<Img> GetImg()
        {
            var list =  (from i in db.Img
                        orderby i.Id
                       select i).Take(4);
            return list.ToList();
        }

    }
}
