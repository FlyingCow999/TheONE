using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flying_Cow_TMSAPI.Model
{
    [Table("Anomaly")]
    /// <summary>
    /// 异常表
    /// </summary>
    public class Anomaly
    {
        [Key]
        /// <summary>
        /// 主键
        /// </summary>
        public int ano_Id { get; set; }
        /// <summary>
        /// 回单表外键
        /// </summary>
        public int aid { get; set; }
        /// <summary>
        /// 解决方案
        /// </summary>
        public string ano_processing { get; set; }
    }
}
