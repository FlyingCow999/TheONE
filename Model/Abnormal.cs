using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Flying_Cow_TMSAPI.Model
{
    [Table("Abnormal")]
    /// <summary>
    /// 回单表
    /// </summary>
    public class Abnormal
    {
        [Key]
        /// <summary>
        /// 主键
        /// </summary>
        public int a_Id { get; set; }
        /// <summary>
        /// 异常状态
        /// </summary>
        public int a_Abnormal { get; set; }
        /// <summary>
        /// 异常说明
        /// </summary>
        public string a_Explain { get; set; }
        /// <summary>
        /// 签收人
        /// </summary>
        public string a_Signer { get; set; }
        /// <summary>
        /// 签收时间 
        /// </summary>
        public DateTime a_Signing { get; set; }
        /// <summary>
        /// 签收状态
        /// </summary>
        public string a_Status { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string a_Picture { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string a_Remarks { get; set; }
        /// <summary>
        /// 卸货外键
        /// </summary>
        public string receiptid { get; set; }
        /// <summary>
        /// 订单外键
        /// </summary>
        public string ifid { get; set; }
    }
}
