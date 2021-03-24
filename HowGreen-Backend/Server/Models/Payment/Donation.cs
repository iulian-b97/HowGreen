using Server.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models.Payment
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
