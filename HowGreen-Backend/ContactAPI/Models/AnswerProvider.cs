using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactAPI.Models
{
    public class AnswerProvider
    {
        public string ContactId { get; set; }
        public string ProviderId { get; set; }
        public string Answer { get; set; }
    }
}
