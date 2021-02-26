using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumptionAPI.Models
{
    public class EnergyLabels
    {
        public string Id { get; set; }
        public string EnergyClass { get; set; }
        public int EfficientIndex { get; set; }
    }
}
