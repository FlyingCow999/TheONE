using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Flying_Cow_TMSAPI.Model
{
    [Table("Consignee")]
    /// <summary>
    /// 收货表
    /// </summary>
    public class Consignee
    {
        [Key]
        public int co_Id { get; set; }
        /// <summary>
        /// 收货方
        /// </summary>
        public string co_Company { get; set; }
        /// <summary>
        /// 收货人
        /// </summary>
        public string co_Person { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string co_Phone { get; set; }
        /// <summary>
        /// 收货地址
        /// </summary>
        public string co_Address { get; set; }
        /// <summary>
        /// 委托表外键
        /// </summary>
        public int eid { get; set; }
        /// <summary>
        /// 订单状态   0：待接单      1：已接单       2：已完成  
        /// </summary>
        public int co_State { get; set; }
    }
}
