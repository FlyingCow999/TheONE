using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Flying_Cow_TMSAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Dapper;
using Microsoft.AspNetCore.Cors;

namespace Flying_Cow_TMSAPI.Controllers
{
    [Produces("application/json", "application/xml")]
    [Route("api/[controller]")]
    [EnableCors("cors")]//设置跨域处理的代理
    [ApiController]
    public class JctionController : ControllerBase
    {
        public TMSDBContext db;
        public JctionController(TMSDBContext db) { this.db = db; }
        private string con = "Data Source=10.3.158.51;Initial Catalog=TMSDB;uid=sa;pwd=123";
        [Route("RoleLogin")]
        [HttpGet]
        public async Task<IEnumerable<Role>> Show(string name)
        {
            var list = from a in db.UserInfo
                       from b in db.UserRole
                       from c in db.Role
                       where a.user_Id == b.userid && b.roleid == c.role_Id && a.user_Name == name
                       select new Role { role_Id = b.roleid };
            return await list.ToListAsync();
        }
        [Route("S")]
        [HttpGet]
        public List<Jurisdiction> RoleJue(string name="")
        {
            using (IDbConnection a = new SqlConnection(con))
            {

                string sql = $"select * from UserInfo a join UserRole b on a.user_Id = b.userid join Role c on b.roleid = c.role_Id where a.user_Name='{name}'";//根据用户名获取数据
                var list = a.Query<Role>(sql).FirstOrDefault().role_Id;
                int id = list;
                string str = $"select Jurisdiction.juris_Id,Jurisdiction.juris_MenuName from Role join RoleJurisdiction on Role.role_Id=RoleJurisdiction.roleid join Jurisdiction on RoleJurisdiction.jurisid=Jurisdiction.juris_Id where Role.role_Id='{id}' and juris_Pid=0";//根据ID查询权限
                return a.Query<Jurisdiction>(str).ToList();
            }
        }
        /// <summary>
        /// 二级菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Two")]
        [HttpGet]
        public List<Jurisdiction> EnumTwo(int ID)
        {
            using (IDbConnection a = new SqlConnection(con))
            {
                string sql = $"select * from Jurisdiction where juris_Pid='{ID}'";
                var list= a.Query<Jurisdiction>(sql).ToList();
                return list;
            }
        }
        [Route("TwoDian")]
        [HttpGet]
        public List<Jurisdiction> Dian(int id)
        {
            using IDbConnection a = new SqlConnection(con);
            //Role 角色表 Jurisdiction菜单表  RoleJurisdiction角色菜单表
            string sql2 = $"select b.role_Id from Role b join RoleJurisdiction c on b.role_Id=c.roleid join Jurisdiction d on c.jurisid=d.juris_Id where d.juris_Pid = '{id}'";
            int Pid = a.Query<Role>(sql2).FirstOrDefault().role_Id;
            string sql = $"select d.juris_Id,d.juris_MenuName,d.juris_Pid,juris_MenuUrl from Role b join RoleJurisdiction c on b.role_Id=c.roleid join Jurisdiction d on c.jurisid=d.juris_Id where 1=1";
            sql += $" and b.role_Id='{Pid}'and d.juris_Pid='{id}'";
            return a.Query<Jurisdiction>(sql).ToList();
        }
    }
}
