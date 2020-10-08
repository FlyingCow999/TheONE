using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flying_Cow_TMSAPI.Model
{
    public class listDAL
    {
        public int code { get; set; }

        public string msg { get; set; }
        public int count { get; set; }
        public List<XSviewModel> data { get; set; }
    }
}
