using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Flying_Cow_TMSAPI.Model
{
    public class Img
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }
    }
}
