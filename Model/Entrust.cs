using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flying_Cow_TMSAPI.Model
{
    [Table("Entrust")]
    /// <summary>
    /// 委托表
    /// </summary>
    public class Entrust
    {
        [Key]
        public int e_Id { get; set; }
        /// <summary>
        /// 委托方
        /// </summary>
        public string e_Company { get; set; }
        /// <summary>
        /// 委托人
        /// </summary>
        public string e_Person { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string e_Phone { get; set; }
        /// <summary>
        /// 提货地址
        /// </summary>
        public string e_Address { get; set; }
        /// <summary>
        /// 提货联系人
        /// </summary>
        public string e_AddPerson { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string e_AddPhone { get; set; }
        /// <summary>
        /// 询价表外键
        /// </summary>
        public int ifid { get; set; }
    }
}
