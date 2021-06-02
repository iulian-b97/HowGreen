using Library.Server.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Server.Entities.Consumption
{
    public class EnergyLabel
    {
        [Key]
        public string Id { get; set; }
        public float TotalConsumption { get; set; }
        public int MP { get; set; }
        public string HouseType { get; set; }

        public string EnergyClass { get; set; }
        public float Index { get; set; }
        public float kW_mpa { get; set; }
        public DateTime Data { get; set; }

        public virtual string FinalConsumptionId { get; set; }
        public virtual string SmallUserId { get; set; }
        public virtual FinalConsumption FinalConsumption { get; set; }
        public virtual SmallUser SmallUser { get; set; }
    }
}
