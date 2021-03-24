using Server.Models.Consumption;
using Server.Models.Contact;
using Server.Models.Payment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models.User
{
    public class SmallUser
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }

        public ICollection<Appliance> Appliances { get; set; }
        public ICollection<FinalConsumption> FinalConsumptions { get; set; }
        public ICollection<EnergyLabel> EnergyLabels { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<Donation> Donations { get; set; }
    }
}
