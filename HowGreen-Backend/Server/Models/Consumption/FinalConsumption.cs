using Server.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models.Consumption
{
    public class FinalConsumption
    {
        public string Id { get; set; }
        public string SmallUserId { get; set; }
        public DateTime Data { get; set; }
        public float nrKw { get; set; }
        public float Price { get; set; }

        public SmallUser SmallUser { get; set; }
        public ICollection<Appliance> Appliances { get; set; }
        public EnergyLabel EnergyLabel { get; set; }
    }
}
