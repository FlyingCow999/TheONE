using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Flying_Cow_TMSAPI.Model
{
    [Table("Dispatch")]
    /// <summary>
    /// 调度表
    /// </summary>
    public class Dispatch
    {
        [Key]
        /// <summary>
        /// 该表的主键
        /// </summary>
        public int dis_Id { get; set; }
        /// <summary>
        /// 与运输方进行关联
        /// </summary>
        public string transportid { get; set; }
        /// <summary>
        /// 与订单表进行关联
        /// </summary>
        public int orderid { get; set; }
        /// <summary>
        /// 判断该订单是否调度
        /// </summary>
        public int dis_State { get; set; }
    }
}
