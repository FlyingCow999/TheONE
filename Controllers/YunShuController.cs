using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flying_Cow_TMSAPI.Migrations;
using Flying_Cow_TMSAPI.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Flying_Cow_TMSAPI.Controllers
{
    /// <summary>
    /// 运输端(司机)
    /// </summary>
    //[Route("api/[controller]/[action]")]
    //// [ApiController]
    //[EnableCors("cors")]
    [Produces("application/json", "application/xml")]
    [Route("api/[controller]")]
    [ApiController]
    public class YunShuController : ControllerBase
    {
        public TMSDBContext db;
        public YunShuController(TMSDBContext db) { this.db = db; }
        //订单管理中获取要接单的页面
        [HttpGet]
        [Route("Takegoods")]
        public FenYe Takegoods(string name, DateTime name2, DateTime name3, int dangqian = 1, int meiyetiaoshu = 8)
        {
            var linq = (from A in db.Inquiry
                        join B in db.Entrust
                        on A.if_Id equals B.e_Id
                        select new InquiryViewModel()
                        {
                            if_Number = A.if_Number,
                            if_OrderTime = A.if_OrderTime,
                            e_Company = B.e_Company,
                            if_PlanBCarTime = A.if_PlanBCarTime,
                            if_PlanArrivalTime = A.if_PlanArrivalTime,
                            if_BeginPlace = A.if_BeginPlace,
                            if_EndPlace = A.if_EndPlace,
                            if_Goods = A.if_Goods,
                            if_Id = A.if_Id,
                            e_Id = B.e_Id,
                            if_AllWeight = A.if_AllWeight,
                            if_State = A.if_State,
                            ZT = A.if_State == 0 ? "等待接单" : A.if_State == 1 ? "已接单" : A.if_State == 2 ? "拒绝" : "过期",
                        }).ToList();
            var count = linq.Count();
            var yi1 = linq.Where(x => x.if_State == 0).Count();
            var yi2 = linq.Where(x => x.if_State == 1).Count();
            var yi3 = linq.Where(x => x.if_State == 2).Count();
            var yi4 = linq.Where(x => x.if_State == 3).Count();
            var list = (from A in db.Inquiry
                        join B in db.Entrust
                        on A.if_Id equals B.e_Id
                        select new InquiryViewModel()
                        {
                            if_Number = A.if_Number,
                            if_OrderTime = A.if_OrderTime,
                            e_Company = B.e_Company,
                            if_PlanBCarTime = A.if_PlanBCarTime,
                            if_PlanArrivalTime = A.if_PlanArrivalTime,
                            if_BeginPlace = A.if_BeginPlace,
                            if_EndPlace = A.if_EndPlace,
                            if_Goods = A.if_Goods,
                            if_Id = A.if_Id,
                            e_Id = B.e_Id,
                            if_AllWeight = A.if_AllWeight,
                            if_State = A.if_State,
                            ZT = A.if_State == 0 ? "等待接单" : A.if_State == 1 ? "已接单" : A.if_State == 2 ? "拒绝" : "过期",
                            qb = count,
                            djjd = yi1,
                            yjd = yi2,
                            jj = yi3,
                            y = yi4

                        }).ToList();
            #region[注释]
            //if (name!=null)
            //{
            //    list.Where(x => x.if_Number.Contains(name)).ToList();
            //}
            //if (name2 != null && name3 != null)
            //{
            //    list = list.Where(d => d.if_PlanBCarTime >= name2 & d.if_PlanArrivalTime <= name3).ToList();
            //}
            #endregion
            if (dangqian < 1)
            {
                dangqian = 1;
            }
            var count1 = list.Count();
            int page;
            if (count1 % meiyetiaoshu == 0)
            {
                page = count1 / meiyetiaoshu;
            }
            else
            {
                page = count1 / meiyetiaoshu + 1;
            }
            FenYe p = new FenYe();
            p.xianshi = list.Skip((dangqian - 1) * meiyetiaoshu).Take(meiyetiaoshu).ToList();
            p.Zongtiaoshu = count1;
            p.Zongyeshu = page;
            p.Dangqianye = dangqian;
            return p;
        }
        [HttpPut]
        [Route("Put")]
        public async Task<ActionResult<int>> Put(string id1, string id2)
        {
            var tod = db.Inquiry.SingleOrDefault(m => m.if_Number == id1);
            if (id2 == "已接单")
            {
                tod.if_State = 1;
            }
            else
            {
                tod.if_State = 2;
            }
            db.Inquiry.Update(tod);
            return await db.SaveChangesAsync();
        }
        //处理订单   接单
        [HttpGet]
        [Route("XianShi")]
        public List<InquiryViewModel> XianShi(string djgl)
        {
            var list = (from A in db.Inquiry
                        join B in db.Entrust
                        on A.if_Id equals B.e_Id
                        select new InquiryViewModel()
                        {
                            if_Number = A.if_Number,
                            if_OrderTime = A.if_OrderTime,
                            e_Company = B.e_Company,
                            if_PlanBCarTime = A.if_PlanBCarTime,
                            if_PlanArrivalTime = A.if_PlanArrivalTime,
                            if_BeginPlace = A.if_BeginPlace,
                            if_EndPlace = A.if_EndPlace,
                            if_Goods = A.if_Goods,
                            if_AllWeight = A.if_AllWeight,
                            if_State = A.if_State,
                            ZT = A.if_State == 1 ? "已接单" : A.if_State == 2 ? "等待接单" : A.if_State == 3 ? "拒绝" : "过期",
                            if_Id = A.if_Id,
                            if_TotalPackage = A.if_TotalPackage,
                            if_BCarTime = A.if_BCarTime,
                            if_Num = A.if_Num,
                            if_Remark = A.if_Remark,
                            if_Specification = A.if_Specification,
                            ifid = B.ifid,
                            e_AddPerson = B.e_AddPerson,
                            e_AddPhone = B.e_AddPhone,
                            e_Address = B.e_Address,
                            e_Person = B.e_Person,
                            e_Phone = B.e_Phone,
                            e_Id = B.e_Id
                        }).ToList(); ;
            if (djgl != null)
            {
                list = list.Where(x => x.if_Number==djgl).ToList();
            }
            return  list;
        }
        [HttpGet]
        [Route("shouhr")]
        public async Task<ActionResult<IEnumerable<Consignee>>> shouhr(int id)
        {
            return await db.Consignee.Where(m => m.eid == id).ToListAsync();
        }
        //应交货物信息
        [HttpGet]
        [Route("yjhwxx")]
        public async Task<ActionResult<IEnumerable<InquiryViewModel>>> yjhwxx(string djgl)
        {
            var list = (from A in db.Inquiry
                        join B in db.Entrust on A.if_Id equals B.e_Id
                        join C in db.Consignee on B.e_Id equals C.eid
                        where A.if_Number == djgl
                        select new InquiryViewModel()
                        {
                            if_Number = A.if_Number,
                            if_OrderTime = A.if_OrderTime,
                            e_Company = B.e_Company,
                            if_PlanBCarTime = A.if_PlanBCarTime,
                            if_PlanArrivalTime = A.if_PlanArrivalTime,
                            if_BeginPlace = A.if_BeginPlace,
                            if_EndPlace = A.if_EndPlace,
                            if_Goods = A.if_Goods,
                            if_AllWeight = A.if_AllWeight,
                            if_State = A.if_State,
                            ZT = A.if_State == 1 ? "已接单" : A.if_State == 2 ? "等待接单" : A.if_State == 3 ? "拒绝" : "过期",
                            if_Id = A.if_Id,
                            if_TotalPackage = A.if_TotalPackage,
                            if_BCarTime = A.if_BCarTime,
                            if_Num = A.if_Num,
                            if_Remark = A.if_Remark,
                            if_Specification = A.if_Specification,
                            ifid = B.ifid,
                            e_AddPerson = B.e_AddPerson,
                            e_AddPhone = B.e_AddPhone,
                            e_Address = B.e_Address,
                            e_Person = B.e_Person,
                            e_Phone = B.e_Phone,
                            e_Id = B.e_Id,
                            eid = C.eid,
                            co_Address = C.co_Address,
                            co_Company = C.co_Company,
                            co_Id = C.co_Id,
                            co_Person = C.co_Person,
                            co_Phone = C.co_Phone,
                            co_State = C.co_State
                        });
            return await list.ToListAsync();
        }
        //应交货物信息
        [HttpGet]
        [Route("ShowXian")]
        public async Task<ActionResult<IEnumerable<InquiryViewModel>>> Show(string djgl)
        {
            var list = (from A in db.Inquiry
                        join B in db.Entrust on A.if_Id equals B.e_Id
                        join C in db.Consignee on B.e_Id equals C.eid
                        where A.if_Number == djgl
                        select new InquiryViewModel()
                        {
                            if_Number = A.if_Number,
                            if_OrderTime = A.if_OrderTime,
                            e_Company = B.e_Company,
                            if_PlanBCarTime = A.if_PlanBCarTime,
                            if_PlanArrivalTime = A.if_PlanArrivalTime,
                            if_BeginPlace = A.if_BeginPlace,
                            if_EndPlace = A.if_EndPlace,
                            if_Goods = A.if_Goods,
                            if_AllWeight = A.if_AllWeight,
                            if_State = A.if_State,
                            ZT = A.if_State == 1 ? "已接单" : A.if_State == 2 ? "等待接单" : A.if_State == 3 ? "拒绝" : "过期",
                            if_Id = A.if_Id,
                            if_TotalPackage = A.if_TotalPackage,
                            if_BCarTime = A.if_BCarTime,
                            if_Num = A.if_Num,
                            if_Remark = A.if_Remark,
                            if_Specification = A.if_Specification,
                            ifid = B.ifid,
                            e_AddPerson = B.e_AddPerson,
                            e_AddPhone = B.e_AddPhone,
                            e_Address = B.e_Address,
                            e_Person = B.e_Person,
                            e_Phone = B.e_Phone,
                            e_Id = B.e_Id,
                            eid = C.eid,
                            co_Address = C.co_Address,
                            co_Company = C.co_Company,
                            co_Id = C.co_Id,
                            co_Person = C.co_Person,
                            co_Phone = C.co_Phone,
                            co_State = C.co_State
                        });
            return await list.ToListAsync();
        }
        // POST api/<AbnormalController>
        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<int>> Post([FromBody] /*Takegoods*/ Receipt m)
        {
            db.Receipt.Add(m);
            return await db.SaveChangesAsync();
        }
        //提货
        [HttpPost]
        [Route("Post")]
        public async Task<ActionResult<int>> Post([FromBody] Takegoods m)
        {
            db.Takegoods.Add(m);
            return await db.SaveChangesAsync();
        }
        /// <summary>
        /// 待报价订单
        /// </summary>
        /// <param name="dangqian"></param>
        /// <param name="meiyetiaoshu"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("dbjdd")]
        public FenYe dbjdd(int dangqian = 1, int meiyetiaoshu = 8)
        {
            var linq = (from A in db.Offer
                        join B in db.Inquiry on A.ciid equals B.if_Id
                        join C in db.Driver_Quotation on A.o_Id equals C.dq_Id
                        select new InquiryViewModel()
                        {
                            if_Number = B.if_Number,
                            if_OrderTime = B.if_OrderTime,
                            if_BeginPlace = B.if_BeginPlace,
                            if_EndPlace = B.if_EndPlace,
                            if_PlanBCarTime = B.if_PlanBCarTime,
                            if_PlanArrivalTime = B.if_PlanArrivalTime,
                            if_Goods = B.if_Goods,
                            if_AllWeight = B.if_AllWeight,
                            if_State = B.if_State,
                           
                        }).ToList();
            var count = linq.Count();
            var ybj = linq.Where(x => x.if_State == 1).Count();
            var wbj = linq.Where(x => x.if_State == 2).Count();
            var gq = linq.Where(x => x.if_State == 3).Count();
            var list = (from A in db.Offer
                        join B in db.Inquiry on A.ciid equals B.if_Id
                        join C in db.Driver_Quotation on A.o_Id equals C.dq_Id
                        select new InquiryViewModel()
                        {
                            if_Number = B.if_Number,
                            if_OrderTime = B.if_OrderTime,
                            if_BeginPlace = B.if_BeginPlace,
                            if_EndPlace = B.if_EndPlace,
                            if_PlanBCarTime = B.if_PlanBCarTime,
                            if_PlanArrivalTime = B.if_PlanArrivalTime,
                            if_Goods = B.if_Goods,
                            if_AllWeight = B.if_AllWeight,
                            if_State = B.if_State,
                            quanbu =count,
                            ybj=ybj,
                            wbj=wbj,
                            gq=gq
                        }).ToList();
            if (dangqian < 1)
            {
                dangqian = 1;
            }
            var count1 = list.Count();
            int page;
            if (count1 % meiyetiaoshu == 0)
            {
                page = count1 / meiyetiaoshu;
            }
            else
            {
                page = count1 / meiyetiaoshu + 1;
            }
            FenYe p = new FenYe();
            p.xianshi = list.Skip((dangqian - 1) * meiyetiaoshu).Take(meiyetiaoshu).ToList();
            p.Zongtiaoshu = count1;
            p.Zongyeshu = page;
            p.Dangqianye = dangqian;
            return p;
        }
        ////报价管理-订单报价
        //[HttpPost]
        //[Route("BaoJia")]
        //public async Task<ActionResult<int>> BaoJia([FromBody] Offer o)
        //{
        //    db.Offer.Add(o);
        //    return await db.SaveChangesAsync();
        //}
        //修改  报价管理-订单报价
        [HttpPut]
        [Route("Upt")]
        public int Put(int id,float o_Price,string o_Capacity,float o_TotalPrice,float o_Other)
        {
            Offer offer = new Offer();
            offer = db.Offer.Where(s => s.o_Id == id).FirstOrDefault();
            offer.o_Price = o_Price;
            offer.o_Capacity = o_Capacity;
            offer.o_TotalPrice = o_TotalPrice;
            offer.o_Other = o_Other;
            db.Offer.Update(offer);
            int i = db.SaveChanges();
            return  i;
        }
        //报价管理-待报价订单
        [HttpGet]
        [Route("BaoJia")]
        public FenYe BaoJia(string djgl, int dangqian = 1, int meiyetiaoshu = 8)
        {
            var linq = (from A in db.Inquiry
                        join B in db.Entrust
                        on A.if_Id equals B.e_Id
                        select new InquiryViewModel()
                        {
                            if_Number = A.if_Number,
                            if_OrderTime = A.if_OrderTime,
                            e_Company = B.e_Company,
                            if_PlanBCarTime = A.if_PlanBCarTime,
                            if_PlanArrivalTime = A.if_PlanArrivalTime,
                            if_BeginPlace = A.if_BeginPlace,
                            if_EndPlace = A.if_EndPlace,
                            if_Goods = A.if_Goods,
                            if_AllWeight = A.if_AllWeight,
                            if_State = A.if_State,
                            ZT = A.if_State == 1 ? "已接单" : A.if_State == 2 ? "等待接单" : A.if_State == 3 ? "拒绝" : "过期",
                            if_Id = A.if_Id,
                            if_TotalPackage = A.if_TotalPackage,
                            if_BCarTime = A.if_BCarTime,
                            if_Num = A.if_Num,
                            if_Remark = A.if_Remark,
                            if_Specification = A.if_Specification,
                            ifid = B.ifid,
                            e_AddPerson = B.e_AddPerson,
                            e_AddPhone = B.e_AddPhone,
                            e_Address = B.e_Address,
                            e_Person = B.e_Person,
                            e_Phone = B.e_Phone,
                            e_Id = B.e_Id
                        }).ToList();
            var count = linq.Count();
            var ybj = linq.Where(x => x.if_State == 1).Count();
            var wbj = linq.Where(x => x.if_State == 2).Count();
            var gq = linq.Where(x => x.if_State == 3).Count();
            var list = (from A in db.Inquiry
                        join B in db.Entrust
                        on A.if_Id equals B.e_Id
                        select new InquiryViewModel()
                        {
                            if_Number = A.if_Number,
                            if_OrderTime = A.if_OrderTime,
                            e_Company = B.e_Company,
                            if_PlanBCarTime = A.if_PlanBCarTime,
                            if_PlanArrivalTime = A.if_PlanArrivalTime,
                            if_BeginPlace = A.if_BeginPlace,
                            if_EndPlace = A.if_EndPlace,
                            if_Goods = A.if_Goods,
                            if_AllWeight = A.if_AllWeight,
                            if_State = A.if_State,
                            ZT = A.if_State == 1 ? "已接单" : A.if_State == 2 ? "等待接单" : A.if_State == 3 ? "拒绝" : "过期",
                            if_Id = A.if_Id,
                            if_TotalPackage = A.if_TotalPackage,
                            if_BCarTime = A.if_BCarTime,
                            if_Num = A.if_Num,
                            if_Remark = A.if_Remark,
                            if_Specification = A.if_Specification,
                            ifid = B.ifid,
                            e_AddPerson = B.e_AddPerson,
                            e_AddPhone = B.e_AddPhone,
                            e_Address = B.e_Address,
                            e_Person = B.e_Person,
                            e_Phone = B.e_Phone,
                            e_Id = B.e_Id,
                            quanbu = count,
                            ybj = ybj,
                            wbj = wbj,
                            gq = gq,
                        }).ToList();
            if (djgl != null)
            {
                list = list.Where(x => x.if_Number == djgl).ToList();
            }
            if (dangqian < 1)
            {
                dangqian = 1;
            }
            var count1 = list.Count();
            int page;
            if (count1 % meiyetiaoshu == 0)
            {
                page = count1 / meiyetiaoshu;
            }
            else
            {
                page = count1 / meiyetiaoshu + 1;
            }
            FenYe p = new FenYe();
            p.xianshi = list.Skip((dangqian - 1) * meiyetiaoshu).Take(meiyetiaoshu).ToList();
            p.Zongtiaoshu = count1;
            p.Zongyeshu = page;
            p.Dangqianye = dangqian;
            return p;
        }
        //[HttpGet]
        //[Route("Takegoods")]
        //public async Task<ActionResult<IEnumerable<Takegoods>>> Takegoods(string name)
        //{
        //    if (name != null)
        //    {
        //        return await db.Takegoods.ToListAsync();
        //    }
        //    else
        //    {
        //        return await db.Takegoods.Where(m => m.t_Station.Contains(name)).ToListAsync();
        //    }
        //}
        ////删除
        //public async Task<ActionResult<int>> Del(int id)
        //{
        //    db.Takegoods.Remove(db.Takegoods.FirstOrDefault(m => m.oid == id));
        //    return await db.SaveChangesAsync();
        //}
        ////修改
        //[HttpPut]
        //[Route("Upt")]
        //public async Task<ActionResult<int>> Put(int id, [FromBody] Takegoods m)
        //{
        //    var tod = db.Takegoods.SingleOrDefault(m => m.oid == id);
        //    tod.t_Article = m.t_Article;
        //    db.Takegoods.Update(tod);
        //    return await db.SaveChangesAsync();
        //}
        ////添加
        //[HttpPost]
        //[Route("Add")]
        //public async Task<ActionResult<int>> Post([FromBody] Takegoods m)
        //{
        //    db.Takegoods.Add(m);
        //    return await db.SaveChangesAsync();
        //}
    }
}
