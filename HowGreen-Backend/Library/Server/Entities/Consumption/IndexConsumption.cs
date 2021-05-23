using Library.Server.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Server.Entities.Consumption
{
    public class IndexConsumption
    {
        [Key]
        public string Id { get; set; }

        public string SmallUserId { get; set; }
        public virtual SmallUser SmallUser { get; set; }
        public virtual ICollection<Appliance> Appliances { get; set; }
        public virtual FinalConsumption FinalConsumption { get; set; }
    }
}
