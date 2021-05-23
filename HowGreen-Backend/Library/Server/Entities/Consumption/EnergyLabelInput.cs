using Library.Server.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.Server.Entities.Consumption
{
    public class EnergyLabelInput
    {
        [Key]
        public string Id { get; set; }
        public float TotalConsumption { get; set; }
        public int MP { get; set; }
        public string TypeHouse { get; set; }

        public string FinalConsumptionId { get; set; }
        public virtual FinalConsumption FinalConsumption { get; set; }
        public virtual EnergyLabelOutput EnergyLabelOutput { get; set; }
    }
}
