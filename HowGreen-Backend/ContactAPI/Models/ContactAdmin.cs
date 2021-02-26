using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactAPI.Models
{
    public class ContactAdmin
    {
        public string MessageId { get; set; }
        public string SenderId { get; set; }
        public string MessageContent { get; set; }
    }
}
