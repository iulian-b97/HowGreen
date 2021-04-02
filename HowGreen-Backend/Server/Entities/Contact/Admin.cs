using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Entities.Contact
{
    public class Admin
    {
        public string Id { get; set; }
        public string Email { get; set; }

        public ICollection<AnswerAdmin> AnswerAdmins { get; set; }
    }
}
