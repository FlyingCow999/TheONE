using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Flying_Cow_TMSAPI.Model
{
    public class XSviewModel
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
        /// 收货方
        /// </summary>
        public string co_Company { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public int co_State { get; set; }
        

        /// <summary>
        /// 运输费
        /// </summary>
        public float o_Freight { get; set; }
    }
}
