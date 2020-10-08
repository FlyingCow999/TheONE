using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flying_Cow_TMSAPI.Model
{
    public class AnomalyPage
    {
        public List<AnomalyViewModel> avm { get; set; }
        //总页数
        public int TotalPage { get; set; }
    }
}
