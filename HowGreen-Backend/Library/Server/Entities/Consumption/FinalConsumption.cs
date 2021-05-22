using Library.Server.Entities.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Server.Entities.Consumption
{
    public class FinalConsumption
    {
        public string IndexConsumptionId { get; set; }
        public string SmallUserId { get; set; }
        public DateTime Data { get; set; }
        public float nrKw { get; set; }
        public float Price { get; set; }

        public SmallUser SmallUser { get; set; }
        public ICollection<Appliance> Appliances { get; set; }
        public ICollection<ApplianceConsumption> ApplianceConsumptions { get; set; }
        public EnergyLabelInput EnergyLabelInput { get; set; }
        public IndexConsumption IndexConsumption { get; set; }
    }
}
