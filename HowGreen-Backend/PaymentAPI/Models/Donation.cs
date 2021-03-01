using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Models
{
    public class Donation
    {
        public string Id { get; set; }
        public string CardType { get; set; }
        public int SumDonated { get; set; }
    }
}
