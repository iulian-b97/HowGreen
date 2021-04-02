using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models.Contact
{
    public class AnswerAdmin
    {
        public string Id { get; set; }
        public string MessageId { get; set; }
        public string AdminId { get; set; }
        public string Answer { get; set; }
    }
}
