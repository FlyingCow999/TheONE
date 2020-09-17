using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flying_Cow_TMSAPI.Model
{
    [Table("UserRole")]
    /// <summary>
    /// 用户角色表
    /// </summary>
    public class UserRole
    {
        [Key]
        /// <summary>
        /// 用户角色表ID
        /// </summary>
        public int usro_Id { get; set; }
        /// <summary>
        /// 用户表外键
        /// </summary>
        public int userid { get; set; }
        /// <summary>
        /// 角色表外键
        /// </summary>
        public int roleid { get; set; }

    }
}
