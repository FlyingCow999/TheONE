using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flying_Cow_TMSAPI.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Flying_Cow_TMSAPI.Controllers
{
    [Produces("application/json", "application/xml")]
    [Route("api/[controller]")]
    [EnableCors("cors")]//设置跨域处理的代理
    public class LoginController : ControllerBase
    {
        public TMSDBContext db;
        public LoginController(TMSDBContext db) { this.db = db; } 

        //[Route("Login")]
        //[HttpGet]
        //public async Task<ActionResult<int>> Login(string name, string mm)
        //{
        //    return await db.UserInfo.Where(s => s.user_Name.Equals(name) && s.user_PassWord.Equals(mm)).CountAsync();
        //}
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<int>> Login(string name, string mm)
        {
            return await db.UserInfo.Where(e => e.user_Name.Equals(name) && e.user_PassWord.Equals(mm)).CountAsync();
        }
        /// <param name="request"></param>
        /// <returns></returns>
        //public int AddUserInfo(UserInfo user)
        //{
        //    int line = 0;
        //    if (!string.IsNullOrEmpty(user.UserName) && !string.IsNullOrEmpty(user.UserPwd))
        //    {
        //        user.CreateTime = DateTime.Now;
        //        line = userIDal.AddUserInfo(user);
        //    }
        //    return line;
        //}
        //注册
        public async Task<ActionResult<int>> enroll(string name,string pwd,string confirm)
        {
            UserInfo u = new UserInfo();
            u.user_Name = name;
            u.user_PassWord = pwd;
            u.user_Confirmpwd = confirm;
            db.UserInfo.Add(u);
            return await db.SaveChangesAsync();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="rname"></param>   
        /// <param name="jmenuURL"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Sel")]
        public async Task<ActionResult<IEnumerable<Jurisdiction>>> Sel(string uname,string rname,string jmenuURL )
        {
            int id = ( from A in db.UserInfo
                       join B in db.UserRole on A.user_Id equals B.userid
                       join C in db.Role on B.roleid equals C.role_Id
                       join D in db.RoleJurisdiction on C.role_Id equals D.roleid
                       join E in db.Jurisdiction on D.jurisid equals E.juris_Id
                       where A.user_Name == uname
                        select new UserInfo()
                        {
                             jurisid=D.jurisid,
                             juris_Id =E.juris_Id,
                             juris_MenuName=E.juris_MenuName,
                             juris_MenuUrl=E.juris_MenuUrl,
                             juris_Pid=E.juris_Pid,
                             roleid=B.roleid,
                             rolej_Id=D.rolej_Id, 
                             role_Id=C.role_Id,
                             role_Name=C.role_Name,
                             userid=B.userid,
                             user_Id=A.user_Id,
                             user_Name=A.user_Name,
                             user_PassWord=A.user_PassWord,
                             user_Phone=A.user_Phone,
                             usro_Id=B.usro_Id
                        }).FirstOrDefault().juris_Id;
            var list = from j in db.Jurisdiction where j.juris_Id == id select j;
            return await list.ToListAsync();
        }
    }
}
