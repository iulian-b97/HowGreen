using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Models
{
    public class StatusPayment
    {
        public string PaymentId { get; set; }
        public bool Status { get; set; }
    }
}
