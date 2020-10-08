using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flying_Cow_TMSAPI.Model
{
    [Table("Jurisdiction")]
    /// <summary>
    /// 权限表
    /// </summary>
    public class Jurisdiction
    {
        [Key]
        /// <summary>
        /// 权限ID
        /// </summary>
        public int juris_Id { get; set; }
        /// <summary>
        /// 权限菜单名称
        /// </summary>
        public string juris_MenuName { get; set; }
        /// <summary>
        /// 父类ID
        /// </summary>
        public int juris_Pid { get; set; }
        /// <summary>
        /// 路径
        /// </summary>
        public string juris_MenuUrl { get; set; }

    }
}
