using Library.Server.Entities.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Server.Entities.Consumption
{
    public class Appliance
    {
        public string Id { get; set; }
        public string SmallUserId { get; set; }
        public string IndexConsumptionId { get; set; }
        public string ApplianceType { get; set; }
        public int nrWatts { get; set; }
        public int hh { get; set; }
        public int mm { get; set; }
        public float priceKw { get; set; }

        public SmallUser SmallUser { get; set; }
        public ApplianceConsumption ApplianceConsumption { get; set; }
        public FinalConsumption FinalConsumption { get; set; }
        public IndexConsumption IndexConsumption { get; set; }
    }
}
