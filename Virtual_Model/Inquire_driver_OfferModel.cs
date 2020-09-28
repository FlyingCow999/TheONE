using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flying_Cow_TMSAPI.Virtual_Model
{
    public class Inquire_driver_OfferModel
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
        public string if_BCarTime { get; set; }
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
        public int dq_Id { get; set; }
        /// <summary>
        /// 询价表外键
        /// </summary>
        public int ifid { get; set; }
        /// <summary>
        /// 报价表外键
        /// </summary>
        public int oid { get; set; }
        public int o_Id { get; set; }
        /// <summary>
        /// 司机姓名
        /// </summary>
        public string o_Driver { get; set; }
        /// <summary>
        /// 车辆性质
        /// </summary>
        public string o_Nature { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        public string o_Row { get; set; }
        /// <summary>
        /// 车型
        /// </summary>
        public string o_Type { get; set; }
        /// <summary>
        /// 车辆规格
        /// </summary>
        public string o_CarSpec { get; set; }
        /// <summary>
        /// 车辆状态
        /// </summary>
        public string o_State { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public float o_Price { get; set; }
        /// <summary>
        /// 载量
        /// </summary>
        public string o_Capacity { get; set; }
        /// <summary>
        /// 发站
        /// </summary>
        public string o_Starting { get; set; }
        /// <summary>
        /// 到站
        /// </summary>
        public string o_Station { get; set; }
        /// <summary>
        /// 额定载量
        /// </summary>
        public int o_Rated { get; set; }
        /// <summary>
        /// 运输费合计
        /// </summary>
        public float o_Freight { get; set; }
        /// <summary>
        /// 其他费用
        /// </summary>
        public float o_Other { get; set; }
        /// <summary>
        /// 网点
        /// </summary>
        public string o_branch { get; set; }
        /// <summary>
        /// 总费用
        /// </summary>
        public float o_TotalPrice { get; set; }
        /// <summary>
        /// 货物表外键
        /// </summary>
        public int ciid { get; set; }
    }
}
