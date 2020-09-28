using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flying_Cow_TMSAPI.Virtual_Model
{
    public class DataCountByState
    {
        //全部
        public string qb { get; set; }
        //待审核
        public string dsh { get; set; }
        //等待询价处理
        public string waitDel { get; set; }
        //询价中
        public string askIng { get; set; }
        //等待添加报价
        public string waitAdd { get; set; }
        //已完成报价
        public string Finish { get; set; }
    }
}
