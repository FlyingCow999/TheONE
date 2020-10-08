using Flying_Cow_TMSAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flying_Cow_TMSAPI.Virtual_Model
{
    /// <summary>
    /// 询价单分页
    /// </summary>
    public class GetInquiryPageList
    {
        //数据
        public List<InquiryData> Inquirie { get; set; }
        //总页数
        public int allPage { get; set; }
    }
}
