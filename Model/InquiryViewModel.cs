using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flying_Cow_TMSAPI.Model
{
    public class InquiryViewModel
    {
        public int if_Id { get; set; }
        /// <summary>
        /// 询价号
        /// </summary>
        public string if_Number { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public string if_OrderTime { get; set; }
        /// <summary>
        /// 计划发车时间
        /// </summary>
        public string if_PlanBCarTime { get; set; }
        /// <summary>
        /// 计划到达时间
        /// </summary>
        public string if_PlanArrivalTime { get; set; }
        /// <summary>
        /// 实际发车时间
        /// </summary>
        public DateTime if_BCarTime { get; set; }
        /// <summary>
        /// 始发地
        /// </summary>
        public string if_BeginPlace { get; set; }
        /// <summary>
        /// 目的地
        /// </summary>
        public string if_EndPlace { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int if_State { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string if_Remark { get; set; }
        /// <summary>
        /// 规格型号
        /// </summary>
        public string if_Specification { get; set; }
        /// <summary>
        /// 总包装
        /// </summary>
        public string if_TotalPackage { get; set; }
        /// <summary>
        /// 总数量
        /// </summary>
        public int if_Num { get; set; }
        /// <summary>
        /// 总重量
        /// </summary>
        public string if_AllWeight { get; set; }
        /// <summary>
        /// 货名
        /// </summary>
        public string if_Goods { get; set; }
        public int e_Id { get; set; }
        /// <summary>
        /// 委托方
        /// </summary>
        public string e_Company { get; set; }
        /// <summary>
        /// 委托人
        /// </summary>
        public string e_Person { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string e_Phone { get; set; }
        /// <summary>
        /// 提货地址
        /// </summary>
        public string e_Address { get; set; }
        /// <summary>
        /// 提货联系人
        /// </summary>
        public string e_AddPerson { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string e_AddPhone { get; set; }
        /// <summary>
        /// 询价表外键
        /// </summary>
        public int ifid { get; set; }
        /// <summary>
        /// 收货方
        /// </summary>
        public string co_Company { get; set; }
        /// <summary>
        /// 收货人
        /// </summary>
        public string co_Person { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string co_Phone { get; set; }
        /// <summary>
        /// 收货地址
        /// </summary>
        public string co_Address { get; set; }
        /// <summary>
        /// 委托表外键
        /// </summary>
        public int eid { get; set; }
        /// <summary>
        /// 订单状态   0：待接单      1：已接单       2：已完成  
        /// </summary>
        public int co_State { get; set; }
        public string ZT { get; set; }
        public int co_Id { get; set; }
        public int quanbu { get; set; }
        public int ybj { get; set; }
        public int wbj { get; set; }
        public int gq { get; set; }
        public int y { get; set; }
        public int jj { get; set; }
        public int yjd { get; set; }
        public int djjd { get; set; }
        public int qb { get; set; }
    }
}
