using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flying_Cow_TMSAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Flying_Cow_TMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class _InquiryController : ControllerBase
    {
        public TMSDBContext db;
        public _InquiryController(TMSDBContext db) { this.db = db; }
        //显示
        [HttpGet]
        [Route("Getlist")]
        public async Task<JSONDAL> Getlist(int page = 1, int limit = 5, string Sfd=null , string Md=null ,int state=-1,string Goods=null)
        {
            var list = await db.Inquiry.OrderByDescending(x => x.if_Id).ToListAsync();

            int acount = list.Count();

            JSONDAL json = new JSONDAL() { code = 0, msg = "", count = acount, data = list };

    
            if (!string.IsNullOrEmpty(Sfd))
            {
                json.data = list.Where(x => x.if_BeginPlace.Contains(Sfd)).Skip((page - 1) * limit).Take(limit).ToList();
            }

            if (!string.IsNullOrEmpty(Md))
            {
                json.data = list.Where(x => x.if_EndPlace.Contains(Md)).Skip((page - 1) * limit).Take(limit).ToList();
            }

            if(!string.IsNullOrEmpty(Goods))
            {
                json.data = list.Where(x => x.if_Goods.Contains(Goods)).Skip((page - 1) * limit).Take(limit).ToList();
            }
            if (state == 0)
            {
                json.data = json.data.Where(x => x.if_State == 0 || x.if_State == 1 || x.if_State == 2 || x.if_State == 3).Skip((page - 1) * limit).Take(limit).ToList();
            }

            if (state == 4)
            {
                json.data = json.data.Where(x => x.if_State.Equals(4)).Skip((page - 1) * limit).Take(limit).ToList();
            }

            if (state == 5)
            {
                json.data = json.data.Where(x => x.if_State.Equals(5)).Skip((page - 1) * limit).Take(limit).ToList();
            }
             if(state==-1)
            {
                json.data = json.data.Skip((page - 1) * limit).Take(limit).ToList();
            }
           
            return json;
        }
        [HttpGet]
        [Route("FT")]
        //下订单(反填)
        public List<FTsbViewModel> FT(int id)
        {
            var list = (from L in db.Inquiry.OrderByDescending(x=>x.if_Id)
                        join E in db.Entrust
                        on L.if_Id equals E.ifid
                        join C in db.Consignee
                        on E.e_Id equals C.eid
                        join o in db.Offer
                        on L.if_Id equals o.ciid
                        join ca in db.Carrier_Profit
                        on o.o_Id equals ca.oid
                        select new FTsbViewModel
                        {
                            if_Id = L.if_Id,
                            //询价号
                            if_Number = L.if_Number,
                            //下订单(询价单转订单过来的状态)当前状态
                            if_State = L.if_State,
                            //始发地
                            if_BeginPlace = L.if_BeginPlace,
                            //目的地
                            if_EndPlace = L.if_EndPlace,
                            //预计发车时间
                            if_PlanBCarTime = L.if_PlanBCarTime,
                            //预计到达时间
                            if_PlanArrivalTime = L.if_PlanArrivalTime,
                            //总重量
                            if_AllWeight=L.if_AllWeight,
                            //规格型号
                            if_Specification = L.if_Specification,
                            //总包装
                            if_TotalPackage = L.if_TotalPackage,
                            //总数量
                            if_Num = L.if_Num,
                            //货名
                            if_Goods = L.if_Goods,
                            //备注
                            if_Remark=L.if_Remark,
                            //价格
                            o_Price = o.o_Price,
                            //运输费
                            o_Freight = o.o_Freight,
                            //司机表offer其他费用
                            o_Other = o.o_Other,
                            //承运商表car其他费用
                            cp_ElseCost = ca.cp_ElseCost,
                            //总计 承运商的总计字段
                            cp_Aggregate = ca.cp_Aggregate,
                            o_Id=o.o_Id
                        });
            list = list.Where(x => x.if_Id.Equals(id));
            return list.ToList();
        }
        [HttpPost]
        [Route("add")]
        //添加Entrust表里字段
        public async Task<ActionResult<int>> add(Entrust en)
        {
            db.Entrust.Add(en);
            return await db.SaveChangesAsync();
        }
        [HttpPost]
        [Route("add1")]
        //添加Consignee表里字段
        public async Task<ActionResult<int>> add1(Consignee co)
        {
            Entrust ent = db.Entrust.OrderByDescending(m => m.e_Id).FirstOrDefault();
             co.eid = ent.e_Id;
            db.Consignee.Add(co);
            return await db.SaveChangesAsync();
        }
        //模态框创建询价单添加
        [HttpPost]
        [Route("aff")]
        public async Task<ActionResult<int>> aff(Inquiry ry)
        {
            CreateCode code = new CreateCode();
            ry.if_Number = code.Code();

            db.Inquiry.Add(ry);
            return await db.SaveChangesAsync();
        }
      
        [HttpGet]
        [Route("Show")]
        //显示订单列表
        public listDAL Show(int page = 1, int limit = 5, string Sfd = null, string Md = null, int state = -1, string Goods = null)
        {
            var list = (from L in db.Inquiry.OrderByDescending(x=>x.if_Id)
                        join E in db.Entrust
                        on L.if_Id equals E.ifid
                        join C in db.Consignee
                        on E.e_Id equals C.eid
                        join o in db.Offer
                        on L.if_Id equals o.ciid
                        select new XSviewModel
                        {
                          if_Id=L.if_Id,
                            //询价号
                            if_Number = L.if_Number,
                            //下单时间
                            if_OrderTime = L.if_OrderTime,
                            //预计发车时间
                            if_PlanBCarTime = L.if_PlanBCarTime,
                            //预计到达时间
                            if_PlanArrivalTime = L.if_PlanArrivalTime,
                            //始发地
                            if_BeginPlace = L.if_BeginPlace,
                            //目的地
                            if_EndPlace = L.if_EndPlace,
                            //收货方
                            co_Company = C.co_Company,
                            //货名
                            if_Goods = L.if_Goods,
                            //总重量
                            if_AllWeight = L.if_AllWeight,
                            //运输费
                            o_Freight = o.o_Freight,
                            //订单状态
                            co_State=C.co_State,

                        }).ToList();

            int acount = list.Count();

            listDAL json = new listDAL() { code = 0, msg = "", count = acount, data = list };

            if (!string.IsNullOrEmpty(Sfd))
            {
                json.data = list.Where(x => x.if_BeginPlace.Contains(Sfd)).Skip((page - 1) * limit).Take(limit).ToList();
            }

            if (!string.IsNullOrEmpty(Md))
            {
                json.data = list.Where(x => x.if_EndPlace.Contains(Md)).Skip((page - 1) * limit).Take(limit).ToList();
            }

            if (!string.IsNullOrEmpty(Goods))
            {
                json.data = list.Where(x => x.if_Goods.Contains(Goods)).Skip((page - 1) * limit).Take(limit).ToList();
            }
            if (state == 0)
            {
                json.data = json.data.Where(x => x.if_State == 0).Skip((page - 1) * limit).Take(limit).ToList();
            }

            if (state == 1)
            {
                json.data = json.data.Where(x => x.if_State.Equals(1)).Skip((page - 1) * limit).Take(limit).ToList();
            }

            if (state == 2)
            {
                json.data = json.data.Where(x => x.if_State.Equals(2)).Skip((page - 1) * limit).Take(limit).ToList();
            }
            if (state == -1)
            {
                json.data = json.data.Skip((page - 1) * limit).Take(limit).ToList();
            }
            return json;
        }
        //订单(已审核)
        [HttpGet]
        [Route("Ysh")]
        public  List<FTsbViewModel> Ysh(int id)
        {
            var list = (from L in db.Inquiry
                        join E in db.Entrust
                        on L.if_Id equals E.ifid
                        join C in db.Consignee
                        on E.e_Id equals C.eid
                        join o in db.Offer
                        on L.if_Id equals o.ciid
                        join ca in db.Carrier_Profit
                        on o.o_Id equals ca.oid
                        select new FTsbViewModel
                      {
                            if_Id = L.if_Id,
                            //询价号
                            if_Number =L.if_Number,
                            //当前状态
                            co_State=C.co_State,
                            //始发地
                           if_BeginPlace=L.if_BeginPlace,
                           //目的地
                           if_EndPlace=L.if_EndPlace,
                            //委托方
                            e_Company = E.e_Company,
                            //委托人
                            e_Person=E.e_Person,
                            //联系电话
                            e_Phone=E.e_Phone,
                            //提货地址
                            e_Address=E.e_Address,
                            //提货联系人
                            e_AddPerson=E.e_AddPerson,
                            //联系电话
                            e_AddPhone=E.e_AddPhone,
                            //收货方
                            co_Company=C.co_Company,
                            //收货人
                            co_Person=C.co_Person,
                            //联系电话
                            co_Phone=C.co_Phone,
                            //收货地址
                            co_Address=C.co_Address,
                            //计划装车时间
                            if_PlanBCarTime=L.if_PlanBCarTime,
                            //计划到达时间
                            if_PlanArrivalTime=L.if_PlanArrivalTime,
                            //货名
                            if_Goods=L.if_Goods,
                            //规格型号
                            if_Specification=L.if_Specification,
                            //总包装
                            if_TotalPackage=L.if_TotalPackage,
                            //总数量
                            if_Num=L.if_Num,
                            //总重量
                            if_AllWeight=L.if_AllWeight,
                            //单价
                            o_Price=o.o_Price,
                            //运输费
                            o_Freight=o.o_Freight,
                            //其他费用司机方
                            o_Other = o.o_Other,
                            //其他费用承运商方
                            cp_Profit=ca.cp_Profit,
                            //总计
                            cp_Aggregate=ca.cp_Aggregate,

                            if_Remark=L.if_Remark,
                        }).ToList();

            list = list.Where(x => x.if_Id == id).ToList();
            return list.ToList();
        }
        [HttpGet]
        [Route("HD")]
        //回单显示
        public List<HDViewModel> HD(int id=0)
        {
            var list = (from L in db.Inquiry
                        join E in db.Entrust
                        on L.if_Id equals E.ifid
                        join CO in db.Consignee
                        on E.e_Id equals CO.eid
                        join Ab in db.Abnormal
                        on L.if_Id equals Ab.coid
                        join R in db.Receipt
                        on Ab.receiptid equals R.r_Id
                        select new HDViewModel
                        {
                            if_Id = L.if_Id,
                            if_Remark=L.if_Remark,
                            if_Number = L.if_Number,
                            if_OrderTime = L.if_OrderTime,
                            co_Company = CO.co_Company,
                            co_Person = CO.co_Person,
                            co_Phone=CO.co_Phone,
                            co_Address=CO.co_Address,
                            if_BeginPlace = L.if_BeginPlace,
                            if_EndPlace = L.if_EndPlace,
                            if_PlanBCarTime=L.if_PlanBCarTime,
                            if_PlanArrivalTime=L.if_PlanArrivalTime,
                            if_Goods = L.if_Goods,
                            if_AllWeight = L.if_AllWeight,
                            if_Num=L.if_Num,
                            if_TotalPackage=L.if_TotalPackage,
                            if_Specification=L.if_Specification,
                            a_State = Ab.a_State,
                            a_Picture=Ab.a_Picture,
                            e_Company =E.e_Company,
                            e_Person=E.e_Person,
                            e_Phone= E.e_Phone,
                            e_Address=E.e_Address,
                            e_AddPerson=E.e_AddPerson,
                            e_AddPhone=E.e_AddPhone,
                            r_Article=R.r_Article,
                            r_Spec=R.r_Spec,
                            r_Number=R.r_Number,
                            r_Weight=R.r_Weight,
                        }) ;
            if(id!=0)
            {
                list = list.Where(x => x.if_Id == id);
            }
            return list.ToList();
        }
        [HttpGet("rk")]
        //修改
        public async Task<ActionResult<int>> rk(int id)
        {
            Abnormal p = db.Abnormal.Find(id);
            p.a_State = 1;
            db.Entry(p).State = EntityState.Modified;
            return await db.SaveChangesAsync();

        }

    }
}
