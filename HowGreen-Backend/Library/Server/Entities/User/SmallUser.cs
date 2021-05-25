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

        public virtual ICollection<IndexConsumption> IndexConsumptions { get; set; }
        public virtual ICollection<Appliance> Appliances { get; set; }
        public virtual ICollection<FinalConsumption> FinalConsumptions { get; set; }
        public virtual ICollection<EnergyLabelInput> EnergyLabelInputs { get; set; }
        public virtual ICollection<EnergyLabelOutput> EnergyLabelOutputs { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public  virtual ICollection<Donation> Donations { get; set; }
    }
}
