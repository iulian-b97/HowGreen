using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models.Contact
{
    public class AnswerProvider
    {
        public string Id { get; set; }
        public string MessageId { get; set; }
        public string ProviderId { get; set; }
        public string Answer { get; set; }

        public Message Message { get; set; }
        public Provider Provider { get; set; }
    }
}
