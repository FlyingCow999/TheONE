using Flying_Cow_TMSAPI.Model;
using Flying_Cow_TMSAPI.Virtual_Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flying_Cow_TMSAPI.Controllers
{
    //[Produces("application/json","application/xml")]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("cors")]
    public class Inquiry_MController : ControllerBase
    {
        //依赖注入
        public TMSDBContext db;
        public Inquiry_MController(TMSDBContext db) { this.db = db; }
        /// <summary>
        /// 显示询价单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetInquiryList")]
        public async Task<GetInquiryPageList> GetInquiryList(string btime = "",string etime = "", string if_number = "", int pageIndex = 1, int pageSize = 4,int state=-2)
        {
            var list = await (from s in db.Inquiry
                              where s.if_State != 5
                              select new InquiryData { 
                             if_AllWeight=s.if_AllWeight,
                             if_BCarTime=s.if_BCarTime.ToString("yyyy-MM-dd HH:mm:ss"),
                             if_BeginPlace=s.if_BeginPlace,
                             if_Specification=s.if_Specification,
                             if_State=s.if_State,
                             if_EndPlace=s.if_EndPlace,
                             if_Goods=s.if_Goods,
                             if_Id=s.if_Id,
                             if_Num=s.if_Num,
                             if_Number=s.if_Number,
                             if_OrderTime=s.if_OrderTime.ToString("yyyy-MM-dd HH:mm:ss"),
                             if_PlanArrivalTime=s.if_PlanArrivalTime.ToString("yyyy-MM-dd HH:mm:ss"),
                             if_PlanBCarTime=s.if_PlanBCarTime.ToString("yyyy-MM-dd HH:mm:ss"),
                             if_Remark=s.if_Remark,
                             if_TotalPackage=s.if_TotalPackage
                              }).OrderByDescending(x=>x.if_Id).ToListAsync();
            //实例化
            GetInquiryPageList data = new GetInquiryPageList();
            if (!string.IsNullOrEmpty(if_number))
            {
                data.Inquirie = list.Where(x => x.if_Number.Contains(if_number)).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
            else if (btime != null)
            {
                data.Inquirie = list.Where(x => Convert.ToDateTime( x.if_OrderTime)>= Convert.ToDateTime(btime )& Convert.ToDateTime(x.if_OrderTime)<= Convert.ToDateTime(etime)).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
            else if(state!=-2)
            {
                if(state==-1)
                {
                    data.Inquirie = list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                }
                else if(state==0)
                {
                    data.Inquirie = list.Where(x => x.if_State == 0).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                }
                else if (state == 1)
                {
                    data.Inquirie = list.Where(x => x.if_State == 1).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                }
                else if (state == 2)
                {
                    data.Inquirie = list.Where(x => x.if_State == 2).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                }
                else if (state == 3)
                {
                    data.Inquirie = list.Where(x => x.if_State == 3).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                }
                else if (state == 4)
                {
                    data.Inquirie = list.Where(x => x.if_State == 4).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                }
            }
            else
            {
                data.Inquirie = list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
            data.allPage = list.Count();
            return data;
        }
        /// <summary>
        /// 审核页面
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetXiangQing")]
        public async Task<ActionResult<IEnumerable<Inquiry>>> GetXiangQing(int Id)
        {
            var list = from s in db.Inquiry
                       where s.if_Id == Id
                       select s;
            return await list.ToListAsync();
        }
        /// <summary>
        /// 审核（修改状态为1）
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("ShenHe")]
        public async Task<ActionResult<int>> ShenHeById(int Id)
        {
            var list = db.Inquiry.Where(x => x.if_Id == Id).FirstOrDefault();
            list.if_State = 1;
            db.Inquiry.Update(list);
            return await db.SaveChangesAsync();
        }
        /// <summary>
        /// 拒绝(修改状态为5)
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("RefuseById")]
        public async Task<ActionResult<int>> RefuseById(int Id)
        {
            var list = db.Inquiry.Where(x => x.if_Id == Id).FirstOrDefault();
            list.if_State = 5;
            db.Inquiry.Update(list);
            return await db.SaveChangesAsync();
        }
        /// <summary>
        /// 司机询价列表(查询询价Id为0，没有报价的数据)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("OfferById")]
        public async Task<ActionResult<IEnumerable<Offer>>> OfferById(string carNo = "", string driver = "", string bPlace = "", string ePlace = "")
        {
            var list = from s in db.Offer
                       where s.ciid == 0
                       select s;
            if (!string.IsNullOrEmpty(carNo))
            {
                list = list.Where(x => x.o_Row.Contains(carNo));
            }
            if (!string.IsNullOrEmpty(driver))
            {
                list = list.Where(x => x.o_Driver.Contains(driver));
            }
            if (!string.IsNullOrEmpty(bPlace))
            {
                list = list.Where(x => x.o_Starting.Contains(bPlace));
            }
            if (!string.IsNullOrEmpty(ePlace))
            {
                list = list.Where(x => x.o_Station.Contains(ePlace));
            }
            return await list.ToListAsync();
        }
        /// <summary>
        /// 添加司机报价
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CommitOffer")]
        public async Task<ActionResult<int>> CommitOffer(int id = 0, string ids = "")
        {
            //切割
            var list1 = ids.TrimEnd(',').Split(',');

            //修改
            foreach (var i in list1)
            {
                //修改报价表中询价单的外键
                var list = db.Offer.Where(x => x.o_Id == Convert.ToInt32(i)).FirstOrDefault();
                list.ciid = id;
                //将司机Id，询价单id添加到司机报价表
                Driver_Quotation driver_Quotation = new Driver_Quotation();
                driver_Quotation.oid = Convert.ToInt32(i);
                driver_Quotation.ifid = id;
                db.Driver_Quotation.Add(driver_Quotation);
                db.Offer.Update(list);
                //修改状态为等待询价（2）
                var list2 = db.Inquiry.Where(x => x.if_Id == id).FirstOrDefault();
                list2.if_State = 2;
            }
            return await db.SaveChangesAsync();
        }

        /// <summary>
        /// 查询司机的报价信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Inquire_driver_Offer")]
        public async Task<ActionResult<List<Inquire_driver_OfferModel>>> Inquire_driver_Offer(int id = 0)
        {
            var list = await (from i in db.Inquiry
                              from o in db.Offer
                              from dq in db.Driver_Quotation
                              where i.if_Id == o.ciid && o.o_Id == dq.oid && i.if_Id == id && i.if_Num != 0
                              select new Inquire_driver_OfferModel
                              {
                                  o_Driver = o.o_Driver,
                                  o_Nature = o.o_Nature,
                                  o_Row = o.o_Row,
                                  o_Type = o.o_Type,
                                  o_CarSpec = o.o_CarSpec,
                                  o_Price = o.o_Price,
                                  o_Capacity = o.o_Capacity,
                                  o_Starting = o.o_Starting,
                                  o_Station = o.o_Station,
                                  o_Rated = o.o_Rated,
                                  o_Freight = o.o_Freight,
                                  o_Other = o.o_Other,
                                  o_TotalPrice = o.o_TotalPrice
                              }).ToListAsync();
            return list;
        }
        /// <summary>
        /// 添加利润，完成报价
        /// </summary>
        /// <param name="cp"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Add_Profits")]
        public async Task<ActionResult<int>> Add_Profits([FromBody] Carrier_Profit cp)
        {
            //添加利润到利润表
            db.Carrier_Profit.Add(cp);
            return await db.SaveChangesAsync();
        }
        /// <summary>
        /// 完成报价(修改状态为4)
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("FinishById")]
        public async Task<ActionResult<int>> FinishById(int Id)
        {
            var list = db.Inquiry.Where(x => x.if_Id == Id).FirstOrDefault();
            list.if_State = 4;
            db.Inquiry.Update(list);
            return await db.SaveChangesAsync();
        }
        /// <summary>
        /// 显示不同状态的个数
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetStateCount")]
        public DataCountByState GetStateCount()
        {
            DataCountByState dcs = new DataCountByState();
            dcs.qb = "全部(" + (from x in db.Inquiry
                              select x).Count() + ")";
            dcs.dsh = "待审核(" + (from x in db.Inquiry
                               where x.if_State == 0
                               select x).Count() + ")";
            dcs.waitDel = "等待询价处理(" + (from x in db.Inquiry
                                   where x.if_State == 1
                                   select x).Count() + ")";
            dcs.askIng = "询价中(" + (from x in db.Inquiry
                                  where x.if_State == 2
                                  select x).Count() + ")";
            dcs.waitAdd = "等待添加报价(" + (from x in db.Inquiry
                                   where x.if_State == 3
                                   select x).Count() + ")";
            dcs.Finish = "已完成报价(" + (from x in db.Inquiry
                                  where x.if_State == 4
                                  select x).Count() + ")";
            return dcs;

        }
        /// <summary>
        /// 详情页
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("XiangQ")]
        public async Task<ActionResult<List<Inquiry>>> XiangQ(int Id)
        {
            var list = from x in db.Inquiry
                       where x.if_Id == Id
                       select x;
            return await list.ToListAsync() ;
        }
        /// <summary>
        /// 获取图片
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetImg")]
        public List<Img> GetImg()
        {
            var list = (from i in db.Img
                       orderby i.Id descending
                       select i).Take(4);
            return list.ToList();
        }
    }
}
