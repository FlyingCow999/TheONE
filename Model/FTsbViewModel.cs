using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Flying_Cow_TMSAPI.Model
{
    public class FTsbViewModel
    {
        [Key]
        public int if_Id { get; set; }
        /// <summary>
        /// 询价号
        /// </summary>
        public string if_Number { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime if_OrderTime { get; set; }
        /// <summary>
        /// 计划发车时间
        /// </summary>
        public DateTime if_PlanBCarTime { get; set; }
        /// <summary>
        /// 计划到达时间
        /// </summary>
        public DateTime if_PlanArrivalTime { get; set; }
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
        /// 订单状态
        /// </summary>
        public int co_State { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public float o_Price { get; set; }
        /// <summary>
        /// 运输费
        /// </summary>
        public float o_Freight { get; set; }
        /// <summary>
        /// 其他费用
        /// </summary>
        public float o_Other { get; set; }
        /// <summary>
        /// 费用合计
        /// </summary>
        public float o_TotalPrice { get; set; }

        /// <summary>
        /// 利润
        /// </summary>
        public float cp_Profit { get; set; }
        /// <summary>
        /// 其他费用
        /// </summary>
        public float cp_ElseCost { get; set; }
        /// <summary>
        /// 报价有效截止日期
        /// </summary>
        public DateTime cp_EndTime { get; set; }
        /// <summary>
        /// 总计
        /// </summary>
        public float cp_Aggregate { get; set; }
        /// <summary>
        /// 货物表外键
        /// </summary>
        public int ciid { get; set; }

        public int o_Id { get; set; }
    }
}
