using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flying_Cow_TMSAPI.Model
{
    public class InquiryPage
    {
        public List<InquiryViewModel> ivm { get; set; }
        //总页数
        public int TotalPage { get; set; }
    }
}
