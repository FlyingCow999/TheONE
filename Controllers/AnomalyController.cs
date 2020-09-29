using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public class AnomalyController : ControllerBase
    {
        //依赖注入
        public TMSDBContext db;
        public AnomalyController(TMSDBContext db) { this.db = db; }

        #region   异常显示主界面

        //显示异常的界面
        [HttpGet]
        [Route("AbnormalList")]
        public async Task<ActionResult<IEnumerable<AnomalyViewModel>>> AbnormalList(string ddh = "", string sb = "")
        {
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
                list = list.Where(s => s.o_Driver.Equals(sb));
            }
            return await list.ToListAsync();
        }
        #endregion


        #region  处理异常界面显示
        [HttpGet]
        [Route("ShowOrderList")]
        public async Task<ActionResult<IEnumerable<AnomalyViewModel>>> ShowOrderList(int id = 0)
        {
            var list = from i in db.Inquiry
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
                           a_Abnormal = a.a_Abnormal,
                           a_Id = a.a_Id,
                           a_Explain = a.a_Explain,
                           a_Picture = a.a_Picture,
                           a_Remarks = a.a_Remarks,
                           a_Signer = a.a_Signer,
                           a_Signing = a.a_Signing,
                           a_Status = a.a_Status,
                           receiptid = a.receiptid,
                           coid = a.coid
                       };
            if (id != 0)
            {
                list = list.Where(s => s.coid.Equals(id));
            }
            return await list.ToListAsync();
        }
        #endregion


        #region  处理异常
        [HttpPost]
        [Route("AddAnomaly")]
        public int AddDispatch([FromBody] Anomaly m)
        {
            int i = 0;
            db.Anomaly.Add(m);
            i += db.SaveChanges();
            int a = m.aid;
            var list = (from ab in db.Abnormal where ab.a_Id == a select ab).FirstOrDefault();
            list.a_Abnormal = 1;
            db.Abnormal.Update(list);
            i += db.SaveChanges();
            return i;
        }
        #endregion
    }
}
