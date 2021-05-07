using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Server.Entities.Payment
{
    public class StatusPayment
    {
        public string Id { get; set; }
        public string PayId { get; set; }
        public bool Status { get; set; }

        public Pay Pay { get; set; }
    }
}

