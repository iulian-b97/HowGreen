using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Entities.Payment
{
    public class StatusPayment
    {
        public string Id { get; set; }
        public string PayId { get; set; }
        public bool Status { get; set; }

        public Pay Pay { get; set; }
    }
}
