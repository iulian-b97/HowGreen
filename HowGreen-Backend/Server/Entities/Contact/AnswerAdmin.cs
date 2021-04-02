using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Entities.Contact
{
    public class AnswerAdmin
    {
        public string Id { get; set; }
        public string MessageId { get; set; }
        public string AdminId { get; set; }
        public string Answer { get; set; }

        public Message Message { get; set; }
        public Admin Admin { get; set; }
    }
}
