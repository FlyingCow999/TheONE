using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flying_Cow_TMSAPI.Model;
namespace Flying_Cow_TMSAPI.Virtual_Model
{
    /// <summary>
    /// 跟踪分页表
    /// </summary>
    public class GetTracePageList
    {
        //数据
        public List<GetTraceModel> GetTraceModel { get; set; }
        //总页数
        public int allPage { get; set; }
    }
}
