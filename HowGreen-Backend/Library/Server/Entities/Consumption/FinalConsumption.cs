using Library.Server.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.Server.Entities.Consumption
{
    public class FinalConsumption
    {
        [Key]
        public string Id { get; set; }
        public DateTime Data { get; set; }
        public float nrKw { get; set; }
        public float Price { get; set; }

        public virtual string IndexConsumptionId { get; set; }
        public virtual string SmallUserId { get; set; }
        public virtual SmallUser SmallUser { get; set; }
        public virtual IndexConsumption IndexConsumption { get; set; }
        public virtual ICollection<Appliance> Appliances { get; set; }
        public virtual EnergyLabelInput EnergyLabelInput { get; set; }
    }
}
