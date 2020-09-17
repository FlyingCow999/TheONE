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
        /// 用户电话
        /// </summary>
        public string user_Phone { get; set; }
    }
}
