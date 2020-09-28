using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flying_Cow_TMSAPI.Model
{
    [Table("Offer")]
    /// <summary>
    /// 报价表
    /// </summary>
    public class Offer
    {
        [Key]
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
        /// 总费用
        /// </summary>
        public float o_TotalPrice { get; set; }
        /// <summary>
        /// 货物表外键
        /// </summary>
        public int ciid { get; set; }
        public string o_branch { get; set; }
    }
}
