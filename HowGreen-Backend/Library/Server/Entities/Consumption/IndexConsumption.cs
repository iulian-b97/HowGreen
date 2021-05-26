using Library.Server.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Server.Entities.Consumption
{
    public class IndexConsumption
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Key]
        public string IndexConsumptionId { get; set; }

        public string SmallUserId { get; set; }
        public virtual SmallUser SmallUser { get; set; }
        public virtual ICollection<Appliance> Appliances { get; set; }
        public virtual FinalConsumption FinalConsumption { get; set; }
    }
}
