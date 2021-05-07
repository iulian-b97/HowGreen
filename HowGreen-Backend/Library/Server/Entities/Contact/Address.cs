using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Server.Entities.Contact
{
    public class Address
    {
        public string Id { get; set; }
        public string ProviderId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }

        public Provider Provider { get; set; }
    }
}
