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
    public class CarrierController : ControllerBase
    {
        //依赖注入
        public TMSDBContext db;
        public CarrierController(TMSDBContext db) { this.db = db; }


        #region  调度
        //显示由询价单转过来的订单
        [HttpGet]
        [Route("GetInquiryInfo")]
        public async Task<ActionResult<IEnumerable<InquiryViewModel>>> GetInquiry(string name = "")
        {
            var list = from i in db.Inquiry
                       join e in db.Entrust on i.if_Id equals e.ifid
                       select new InquiryViewModel
                       {
                           e_AddPerson = e.e_AddPerson,
                           e_AddPhone = e.e_AddPhone,
                           e_Address = e.e_Address,
                           e_Company = e.e_Company,
                           e_Id = e.e_Id,
                           e_Person = e.e_Person,
                           e_Phone = e.e_Phone,
                           ifid = i.if_Id,
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
                           if_TotalPackage = i.if_TotalPackage
                       };
            //if (!string.IsNullOrEmpty(name))
            //{
            //    return await list.Where(s => s.ClientName.Contains(name)).ToListAsync();
            //}
            return await list.ToListAsync();
        }
        //显示所有的司机信息
        [HttpGet]
        [Route("GetOfferInfo")]
        public async Task<ActionResult<IEnumerable<Offer>>> GetOffer (string start = "",string end="")
        {
            var list = from off in db.Offer select off;
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
        //查询符合当前订单的司机信息
        //调度
        [HttpPost]
        [Route("AddDispatch")]
        public async Task<ActionResult<int>> AddDispatch([FromBody] Dispatch m)
        {
            db.Dispatch.Add(m);
            return await db.SaveChangesAsync();
        }
        #endregion

        #region  异常

        #endregion

    }
}
