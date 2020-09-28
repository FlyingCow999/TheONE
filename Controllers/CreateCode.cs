using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flying_Cow_TMSAPI.Controllers
{
    public class CreateCode
    {
        //系统后台自动生成编号
        public string Code() 
        {
            return "sp" +DateTime.Now.ToString().Replace("/","").Replace(":","").Replace(" ","");
        }
    }
}
