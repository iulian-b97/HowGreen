using Server.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models.Contact
{
    public class Message
    {
        public string Id { get; set; }
        public string SmallUserId { get; set; }
        public string MessageContent { get; set; }

        public SmallUser SmallUser { get; set; }
        public AnswerAdmin AnswerAdmin { get; set; }
        public AnswerProvider AnswerProvider { get; set; }
    }
}
