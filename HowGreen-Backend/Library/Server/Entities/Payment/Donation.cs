using Library.Server.Entities.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Server.Entities.Payment
{
    public class Donation
    {
        public string Id { get; set; }
        public string SmallUserId { get; set; }
        public string CardType { get; set; }
        public int SumDonated { get; set; }

        public SmallUser SmallUser { get; set; }
        public Pay Pay { get; set; }
    }
}

