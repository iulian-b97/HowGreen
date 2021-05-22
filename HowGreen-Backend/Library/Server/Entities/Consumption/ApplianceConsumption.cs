using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Server.Entities.Consumption
{
    public class ApplianceConsumption
    {
        public string Id { get; set; }
        public string ApplianceId { get; set; }
        public string IndexConsumptionId { get; set; }
        public string ApplianceType { get; set; }
        public int nrWatts { get; set; }
        public int hh { get; set; }
        public int mm { get; set; }
        public float kwMonth { get; set; }
        public float priceMonth { get; set; }

        public Appliance Appliance { get; set; }
        public FinalConsumption FinalConsumption { get; set; }
        public IndexConsumption IndexConsumption { get; set; }
    }
}
