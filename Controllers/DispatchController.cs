using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Flying_Cow_TMSAPI.Model;

namespace Flying_Cow_TMSAPI.Controllers
{
    //改变响应格式
    [Produces("application/json", "application/xml")]
    [Route("api/[controller]")]
    [ApiController]
    public class DispatchController : ControllerBase
    {
        //依赖注入
        public TMSDBContext db;
        public DispatchController(TMSDBContext db) { this.db = db; }


        #region  调度
        //显示由询价单转过来的订单
        [HttpGet]
        [Route("GetInquiryInfo")]
        public InquiryPage GetInquiry(string ddh = "", string gs = "", int pageIndex = 1, int pageSize = 5)
        {
            var list = from i in db.Inquiry.OrderByDescending(s => s.if_OrderTime)
                       join e in db.Entrust on i.if_Id equals e.ifid
                       join c in db.Consignee on e.e_Id equals c.eid
                       where c.co_State == 0
                       select new InquiryViewModel
                       {
                           e_AddPerson = e.e_AddPerson,
                           e_AddPhone = e.e_AddPhone,
                           e_Address = e.e_Address,
                           e_Company = e.e_Company,
                           e_Id = e.e_Id,
                           e_Person = e.e_Person,
                           e_Phone = e.e_Phone,
                           if_AllWeight = i.if_AllWeight,
                           if_Id = i.if_Id,
                           if_BCarTime = i.if_BCarTime,
                           if_BeginPlace = i.if_BeginPlace,
                           if_EndPlace = i.if_EndPlace,
                           if_Goods = i.if_Goods,
                           if_Num = i.if_Num,
                           if_Number = i.if_Number,
                           if_OrderTime = i.if_OrderTime.ToString("yyyy-MM-dd HH:mm:ss"),
                           if_PlanArrivalTime = i.if_PlanArrivalTime.ToString("yyyy-MM-dd HH:mm:ss"),
                           if_PlanBCarTime = i.if_PlanBCarTime.ToString("yyyy-MM-dd HH:mm:ss"),
                           if_Remark = i.if_Remark,
                           if_Specification = i.if_Specification,
                           if_State = i.if_State,
                           if_TotalPackage = i.if_TotalPackage,
                           co_State = c.co_State,
                           co_Address = c.co_Address,
                           eid = c.eid,
                           co_Company = c.co_Company,
                           co_Person = c.co_Person,
                           co_Phone = c.co_Phone
                       };
            if (!string.IsNullOrEmpty(ddh))
            {
                list = list.Where(s => s.if_Number.Equals(ddh));
            }
            if (!string.IsNullOrEmpty(gs))
            {
                list = list.Where(s => s.e_Company.Contains(gs));
            }
            int count = list.Count();
            InquiryPage page = new InquiryPage();
            list = list.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            page.ivm = list.ToList();
            if (count % pageSize == 0)
            {
                page.TotalPage = count / pageSize;
            }
            else
            {
                page.TotalPage = count / pageSize + 1;
            }
            return page;
        }
        //调度显示(委托方+收货方+订单信息)
        [HttpGet]
        [Route("GetAllList")]
        public async Task<ActionResult<IEnumerable<DispatchViewModel>>> GetAllList(int code)
        {
            var list = from i in db.Inquiry
                       join e in db.Entrust on i.if_Id equals e.ifid
                       join cs in db.Consignee on e.e_Id equals cs.eid
                       where i.if_Id == code
                       select new DispatchViewModel
                       {
                           e_AddPerson = e.e_AddPerson,
                           e_AddPhone = e.e_AddPhone,
                           e_Address = e.e_Address,
                           e_Company = e.e_Company,
                           e_Id = e.e_Id,
                           e_Person = e.e_Person,
                           e_Phone = e.e_Phone,
                           if_AllWeight = i.if_AllWeight,
                           if_Id = i.if_Id,
                           if_BCarTime = i.if_BCarTime.ToString("yyyy-MM-dd HH-mm-ss"),
                           if_BeginPlace = i.if_BeginPlace,
                           if_EndPlace = i.if_EndPlace,
                           if_Goods = i.if_Goods,
                           if_Num = i.if_Num,
                           if_Number = i.if_Number,
                           if_OrderTime = i.if_OrderTime.ToString("yyyy-MM-dd HH-mm-ss"),
                           if_PlanArrivalTime = i.if_PlanArrivalTime.ToString("yyyy-MM-dd HH-mm-ss"),
                           if_PlanBCarTime = i.if_PlanBCarTime.ToString("yyyy-MM-dd HH-mm-ss"),
                           if_Remark = i.if_Remark,
                           if_Specification = i.if_Specification,
                           if_State = i.if_State,
                           if_TotalPackage = i.if_TotalPackage,
                           co_Address = cs.co_Address,
                           eid = cs.eid,
                           co_Company = cs.co_Company,
                           co_Person = cs.co_Person,
                           co_Phone = cs.co_Phone,
                           co_State = cs.co_State,
                           ifid = e.ifid
                       };
            //if (code != 0)
            //{
            //    list = list.Where(s => s.if_Id.Equals(code));
            //}
            return await list.ToListAsync();
        }
        //根据订单号查询司机报价 
        [HttpGet]
        [Route("GetOfferList")]
        public async Task<ActionResult<IEnumerable<OfferViewModel>>> GetOfferList(int code = 0)
        {
            var list = from of in db.Offer
                       join i in db.Inquiry on of.ciid equals i.if_Id
                       join e in db.Entrust on i.if_Id equals e.ifid
                       join cs in db.Consignee on e.e_Id equals cs.eid
                       select new OfferViewModel
                       {
                           if_AllWeight = i.if_AllWeight,
                           if_Id = i.if_Id,
                           if_BCarTime = i.if_BCarTime,
                           if_BeginPlace = i.if_BeginPlace,
                           if_EndPlace = i.if_EndPlace,
                           if_Goods = i.if_Goods,
                           if_Num = i.if_Num,
                           if_Number = i.if_Number,
                           if_OrderTime = i.if_OrderTime,
                           if_PlanArrivalTime = i.if_PlanArrivalTime,
                           if_PlanBCarTime = i.if_PlanBCarTime,
                           if_Remark = i.if_Remark,
                           if_Specification = i.if_Specification,
                           if_State = i.if_State,
                           if_TotalPackage = i.if_TotalPackage,
                           ciid = of.ciid,
                           o_Capacity = of.o_Capacity,
                           o_CarSpec = of.o_CarSpec,
                           o_Driver = of.o_Driver,
                           o_Freight = of.o_Freight,
                           o_Id = of.o_Id,
                           o_Nature = of.o_Nature,
                           o_Other = of.o_Other,
                           o_Price = of.o_Price,
                           o_Rated = of.o_Rated,
                           o_Row = of.o_Row,
                           o_Starting = of.o_Starting,
                           o_State = of.o_State,
                           o_Station = of.o_Station,
                           o_TotalPrice = of.o_TotalPrice,
                           o_Type = of.o_Type,
                           o_branch = of.o_branch,
                           co_Address = cs.co_Address,
                           co_Company = cs.co_Company,
                           co_Person = cs.co_Person,
                           co_Phone = cs.co_Phone,
                           co_State = cs.co_State,
                           eid = cs.eid,
                           e_AddPerson = e.e_AddPerson,
                           e_AddPhone = e.e_AddPhone,
                           e_Address = e.e_Address,
                           e_Company = e.e_Company,
                           e_Person = e.e_Person,
                           e_Phone = e.e_Phone
                       };
            if (code != 0)
            {
                list = list.Where(s => s.if_Id == code);
            }
            return await list.ToListAsync();
        }
        //显示所有的司机信息(除了接受订单那位)
        [HttpGet]
        [Route("GetOfferInfo")]
        public async Task<ActionResult<IEnumerable<Offer>>> GetOffer(int code = 0, string start = "", string end = "")
        {
            var name = (from of in db.Offer
                        join i in db.Inquiry on of.ciid equals i.if_Id
                        join e in db.Entrust on i.if_Id equals e.ifid
                        join cs in db.Consignee on e.e_Id equals cs.eid
                        where i.if_Id == code
                        select new OfferViewModel
                        {
                            o_Driver = of.o_Driver,
                        }).FirstOrDefault().o_Driver;

            var list = from of in db.Offer
                       where of.o_Driver != name
                       select of;
            if (!string.IsNullOrEmpty(start))
            {
                list = list.Where(s => s.o_Starting.Contains(start));
            }
            if (!string.IsNullOrEmpty(end))
            {
                list = list.Where(s => s.o_Station.Contains(end));
            }
            if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
            {
                list = list.Where(s => s.o_Starting.Contains(start) && s.o_Station.Contains(end));
            }
            return await list.ToListAsync();
        }
        //修改调度表
        [HttpPost]
        [Route("AddDispatch")]
        public async Task<ActionResult<int>> AddDispatch([FromBody] Dispatch m)
        {
            //db.Dispatch.Add(m);

            Dispatch a = new Dispatch();
            a.transportid = m.transportid;
            a.orderid = m.orderid;
            a.dis_State = 1;
            db.Dispatch.Update(a);

            //Consignee con = new Consignee();
            //var list=db.Consignee.Where(s=>s.)


            return await db.SaveChangesAsync();
        }
        #endregion


    }
}
