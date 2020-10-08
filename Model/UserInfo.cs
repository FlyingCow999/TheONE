using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flying_Cow_TMSAPI.Model
{
    [Table("UserInfo")]
    /// <summary>
    /// 用户表
    /// </summary>
    public class UserInfo
    {
        [Key]
        /// <summary>
        /// 用户表ID
        /// </summary>
        public int user_Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string user_Name { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string user_PassWord { get; set; }
        /// <summary>
        /// 确认密码
        /// </summary>
        public string user_Confirmpwd { get; set; }
        /// <summary>
        /// 用户电话
        /// </summary>
        public string user_Phone { get; set; }
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
        public string role_gRemark { get; set; }
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
        /// <summary>
        /// 用户角色表ID
        /// </summary>
        public int usro_Id { get; set; }
        /// <summary>
        /// 用户表外键
        /// </summary>
        public int userid { get; set; }
        
    }
}
