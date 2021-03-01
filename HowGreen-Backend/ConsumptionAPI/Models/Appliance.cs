using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumptionAPI.Models
{
    public class Appliance
    {
        public string UserId { get; set; }
        public string ConsumptionId { get; set; }
        public string ApplianceType { get; set; }
        public int nrWatts { get; set; }
        public int hoursDay { get; set; }
        public int priceKw { get; set; }
    }
}
