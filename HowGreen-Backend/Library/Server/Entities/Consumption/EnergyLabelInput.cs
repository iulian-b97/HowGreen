using Library.Server.Entities.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Server.Entities.Consumption
{
    public class EnergyLabelInput
    {
        public string Id { get; set; }
        public string SmallUserId { get; set; }
        public string IndexConsumptionId { get; set; }
        public float TotalConsumption { get; set; }
        public int MP { get; set; }
        public string TypeHouse { get; set; }

        public SmallUser SmallUser { get; set; }
        public FinalConsumption FinalConsumption { get; set; }
        public IndexConsumption IndexConsumption { get; set; }
        public EnergyLabelOutput EnergyLabelOutput { get; set; }
    }
}
