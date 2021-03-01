using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactAPI.Models
{
    public class AnswerAdmin
    {
        public string ContactId { get; set; }
        public string AdminId { get; set; }
        public string Answer { get; set; }
    }
}
