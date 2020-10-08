using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flying_Cow_TMSAPI.Model
{
    [Table("Route")]
    /// <summary>
    /// 路线表
    /// </summary>
    public class Route
    {
        [Key]
        /// <summary>
        /// 主键
        /// </summary>
        public int r_Id { get; set; }
        /// <summary>
        /// 途中站 
        /// </summary>
        public string r_Pass { get; set; }
        /// <summary>
        /// 订单表外键
        /// </summary>
        public int ifid { get; set; }
        /// <summary>
        /// 到达时间
        /// </summary>
        public DateTime r_Time { get; set; } 
    }
}
