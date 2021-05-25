using Library.Server.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.Server.Entities.Consumption
{
    public class Appliance
    {
        [Key]
        public string Id { get; set; }
        public string ApplianceType { get; set; }
        public int nrWatts { get; set; }
        public int hh { get; set; }
        public int mm { get; set; }
        public float priceKw { get; set; }  
        public float kwMonth { get; set; }
        public float priceMonth { get; set; }

        public virtual string SmallUserId { get; set; }
        public virtual SmallUser SmallUser { get; set; }
        public virtual string IndexConsumptionId { get; set; }
        public virtual IndexConsumption IndexConsumption { get; set; }
        public virtual string FinalConsumptionId { get; set; }
        public virtual FinalConsumption FinalConsumption { get; set; }
    }
}
