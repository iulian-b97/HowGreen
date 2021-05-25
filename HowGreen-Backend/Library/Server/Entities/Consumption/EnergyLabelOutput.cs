using Library.Server.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Server.Entities.Consumption
{
    public class EnergyLabelOutput
    {
        [Key]
        public string Id { get; set; }
        public string EnergyClass { get; set; }
        public float Index { get; set; }
        public float kW_mpa { get; set; }
        public string TypeHouse { get; set; }
        public DateTime Data { get; set; }

        public string SmallUserId { get; set; }
        public string FinalConsumptionId { get; set; }
        public string EnergyLabelInputId { get; set; }
        public virtual SmallUser SmallUser { get; set; }
        public virtual EnergyLabelInput EnergyLabelInput { get; set; }
        public virtual FinalConsumption FinalConsumption { get; set; }
    }
}
