using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models.Payment
{
    public class Pay
    {
        public string Id { get; set; }
        public string DonationId { get; set; }
        public string CardOwnerName { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode { get; set; }

        public Donation Donation { get; set; }
        public StatusPayment StatusPayment { get; set; }
    }
}
