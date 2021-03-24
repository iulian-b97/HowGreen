using Server.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models.Consumption
{
    public class Appliance
    {
        public string Id { get; set; }
        public string SmallUserId { get; set; }
        public string FinalConsumptionId { get; set; }
        public string ApplianceType { get; set; }
        public int nrWatts { get; set; }
        public int hoursDay { get; set; }
        public int priceKw { get; set; }

        public SmallUser SmallUser { get; set; }
        public FinalConsumption FinalConsumption { get; set; }
    }
}
