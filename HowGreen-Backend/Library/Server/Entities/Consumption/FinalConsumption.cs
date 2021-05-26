using Library.Server.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Library.Server.Entities.Consumption
{
    public class FinalConsumption
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Key]
        public string FinalConsumptionId { get; set; }
        public DateTime Data { get; set; }
        public float nrKw { get; set; }
        public float Price { get; set; }

        public virtual string IndexConsumptionId { get; set; }
        public virtual string SmallUserId { get; set; }
        public virtual SmallUser SmallUser { get; set; }
        public virtual IndexConsumption IndexConsumption { get; set; }
        public virtual ICollection<Appliance> Appliances { get; set; }
        public virtual EnergyLabelInput EnergyLabelInput { get; set; }
        public virtual EnergyLabelOutput EnergyLabelOutput { get; set; }
    }
}
