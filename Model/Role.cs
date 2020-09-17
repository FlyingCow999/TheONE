using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flying_Cow_TMSAPI.Model
{
    [Table("Role")]
    /// <summary>
    /// 角色表
    /// </summary>
    public class Role
    {
        [Key]
        /// <summary>
        /// 角色ID
        /// </summary>
        public int role_Id { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string role_Name { get; set; }
        /// <summary>
        /// 角色权限
        /// </summary>
        public string role_Remark { get; set; }
    }
}
