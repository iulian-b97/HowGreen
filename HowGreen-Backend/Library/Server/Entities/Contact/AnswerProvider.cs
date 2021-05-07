using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Server.Entities.Contact
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
