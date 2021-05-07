using Library.Server.Entities.Consumption;
using Library.Server.Entities.Contact;
using Library.Server.Entities.Payment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.Server.Entities.User
{
    public class SmallUser
    {
        [Key]
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public ICollection<Appliance> Appliances { get; set; }
        public ICollection<FinalConsumption> FinalConsumptions { get; set; }
        public ICollection<EnergyLabel> EnergyLabels { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<Donation> Donations { get; set; }
    }
}
