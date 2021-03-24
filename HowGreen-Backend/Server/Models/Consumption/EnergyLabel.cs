using Server.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models.Consumption
{
    public class EnergyLabel
    {
        public string Id { get; set; }
        public string SmallUserId { get; set; }
        public string FinalConsumptionId { get; set; }
        public string EnergyClass { get; set; }
        public int EfficientIndex { get; set; }

        public SmallUser SmallUser { get; set; }
        public FinalConsumption FinalConsumption { get; set; }
    }
}
