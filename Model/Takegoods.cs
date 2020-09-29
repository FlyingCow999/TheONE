using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flying_Cow_TMSAPI.Model
{
    [Table("Takegoods")]
    /// <summary>
    /// 提货表
    /// </summary>
    public class Takegoods
    {
        [Key]
        /// <summary>
        /// 主键
        /// </summary>
        public int t_Id { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string t_Order { get; set; }
        /// <summary>
        /// 货名
        /// </summary>
        public string t_Article { get; set; }
        /// <summary>
        /// 规格型号
        /// </summary>
        public string t_Spec { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int t_Number { get; set; }
        /// <summary>
        /// 总重量
        /// </summary>
        public float t_Weight { get; set; }
        /// <summary>
        /// 始发地址
        /// </summary>
        public string t_Origin { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string t_Picture { get; set; }
        /// <summary>
        /// 签收时间 
        /// </summary>
        public DateTime t_Signing { get; set; }
        /// <summary>
        /// 报价表外键
        /// </summary>
        public int oid { get; set; }
    }
}
