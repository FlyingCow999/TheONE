using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flying_Cow_TMSAPI.Model
{
    [Table("RoleJurisdiction")]
    /// <summary>
    /// 角色权限表
    /// </summary>
    public class RoleJurisdiction
    {

        [Key]
        /// <summary>
        /// 角色权限表ID
        /// </summary>
        public int rolej_Id { get; set; }
        /// <summary>
        /// 角色表外键
        /// </summary>
        public int roleid { get; set; }
        /// <summary>
        /// 权限表外键
        /// </summary>
        public int jurisid { get; set; }
    }
}
