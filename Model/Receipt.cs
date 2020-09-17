using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flying_Cow_TMSAPI.Model
{
    [Table("Receipt")]
    /// <summary>
    /// 卸货单
    /// </summary>
    public class Receipt
    {
        [Key]
        /// <summary>
        /// 主键
        /// </summary>
        public int r_Id { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string r_Order { get; set; }
        /// <summary>
        /// 货名
        /// </summary>
        public string r_Article { get; set; }
        /// <summary>
        /// 规格型号
        /// </summary>
        public string r_Spec { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int r_Number { get; set; }
        /// <summary>
        /// 重量
        /// </summary>
        public int r_Weight { get; set; }
        /// <summary>
        /// 体积
        /// </summary>
        public string r_Volume { get; set; }
    }
}
