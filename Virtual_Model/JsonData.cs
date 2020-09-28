using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flying_Cow_TMSAPI.Virtual_Model
{
        public class JsonData
        {
            public int code { get; set; }
            public int count { get; set; }
            public string msg { get; set; }
            public List<GetTraceModel> data { get; set; }
        }
}
