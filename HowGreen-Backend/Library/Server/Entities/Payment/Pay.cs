using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Server.Entities.Payment
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
