using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Server.Entities.Consumption
{
    public class IndexConsumption
    {
        public string Id { get; set; }

        public ICollection<Appliance> Appliances { get; set; }
        public ICollection<ApplianceConsumption> ApplianceConsumptions { get; set; }
        public FinalConsumption FinalConsumption { get; set; }
        public EnergyLabelInput EnergyLabelInput { get; set; }
    }
}
