using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flying_Cow_TMSAPI.Model
{
    [Table("Driver_Quotation")]
    /// <summary>
    /// 司机报价表
    /// </summary>
    public class Driver_Quotation
    {
        [Key]
        /// <summary>
        /// 主键
        /// </summary>
        public int dq_Id { get; set; }
        /// <summary>
        /// 询价表外键
        /// </summary>
        public int ifid { get; set; }
        /// <summary>
        /// 报价表外键
        /// </summary>
        public int oid { get; set; }
    }
}
