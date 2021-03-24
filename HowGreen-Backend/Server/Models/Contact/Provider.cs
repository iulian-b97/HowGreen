using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models.Contact
{
    public class Provider
    {
        public string Id { get; set; }
        public string CompanyName { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }

        public ICollection<AnswerProvider> AnswerProviders { get; set; }
        public Address Address { get; set; }
    }
}
