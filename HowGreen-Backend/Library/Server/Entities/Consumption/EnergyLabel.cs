using Library.Server.Entities.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Server.Entities.Consumption
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
