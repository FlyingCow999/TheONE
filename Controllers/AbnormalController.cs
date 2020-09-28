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

    //改变响应格式
    [Produces("application/json", "application/xml")]
    [Route("api/[controller]")]
    [ApiController]
    public class AbnormalController : ControllerBase
    {

        //依赖注入
        public TMSDBContext db;
        public AbnormalController(TMSDBContext db) { this.db = db; }


        #region   回单显示界面
        //显示回单的界面
        [HttpGet]
        [Route("GetAbnormalList")]
        public async Task<ActionResult<IEnumerable<AnomalyViewModel>>> AbnormalList(string ddh = "", string sb = "")
        {
            //offer     inquiry     entrust      abnormal
            var list = from of in db.Offer
                       join i in db.Inquiry on of.ciid equals i.if_Id
                       join e in db.Entrust on i.if_Id equals e.ifid
                       join a in db.Abnormal on i.if_Id equals a.coid
                       select new AnomalyViewModel
                       {
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
                           e_AddPerson = e.e_AddPerson,
                           e_AddPhone = e.e_AddPhone,
                           e_Address = e.e_Address,
                           e_Company = e.e_Company,
                           e_Person = e.e_Person,
                           e_Phone = e.e_Phone,
                           a_Abnormal = a.a_Abnormal,
                           a_Id = a.a_Id,
                           a_Explain = a.a_Explain,
                           a_Picture = a.a_Picture,
                           a_Remarks = a.a_Remarks,
                           a_Signer = a.a_Signer,
                           a_Signing = a.a_Signing,
                           a_Status = a.a_Status,
                           e_Id = e.e_Id,
                           receiptid = a.receiptid,
                           coid = a.coid
                       };
            if (!string.IsNullOrEmpty(ddh))
            {
                list = list.Where(s => s.if_Number.Equals(ddh));
            }
            if (!string.IsNullOrEmpty(sb))
            {
                list = list.Where(s => s.e_Company.Contains(sb));
            }
            return await list.ToListAsync();
        }
        #endregion


        #region    回单的详细信息
        //显示回单的界面
        [HttpGet]
        [Route("GetAllAbnormalList")]
        public async Task<ActionResult<IEnumerable<AnomalyViewModel>>> GetAllAbnormalList(int code = 0)
        {
            //offer     inquiry     entrust      abnormal
            var list = from i in db.Inquiry
                       join e in db.Entrust on i.if_Id equals e.ifid                      
                       join c in db.Consignee on e.e_Id equals c.eid
                       join ab in db.Abnormal on i.if_Id equals ab.coid
                       join re in db.Receipt on i.if_Id equals re.r_Order
                       select new AnomalyViewModel
                       {
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
                           e_AddPerson = e.e_AddPerson,
                           e_AddPhone = e.e_AddPhone,
                           e_Address = e.e_Address,
                           e_Company = e.e_Company,
                           e_Person = e.e_Person,
                           e_Phone = e.e_Phone,
                           a_Abnormal = ab.a_Abnormal,
                           a_Id = ab.a_Id,
                           a_Explain = ab.a_Explain,
                           a_Picture = ab.a_Picture,
                           a_Remarks = ab.a_Remarks,
                           a_Signer = ab.a_Signer,
                           a_Signing = ab.a_Signing,
                           a_Status = ab.a_Status,
                           e_Id = e.e_Id,
                           receiptid = ab.receiptid,
                           coid = ab.coid,
                           co_Address = c.co_Address,
                           co_Company = c.co_Company,
                           co_Person = c.co_Person,
                           co_Phone = c.co_Phone,
                           co_State = c.co_State,
                           r_Order = re.r_Order,
                           r_Weight = re.r_Weight,
                           r_Article = re.r_Article,
                           r_Number = re.r_Number,
                           r_Spec = re.r_Spec                            
                       };
            if (code != 0)
            {
                list = list.Where(s => s.if_Id.Equals(code));
            }
            return await list.ToListAsync();
        }
        #endregion
    }
}
