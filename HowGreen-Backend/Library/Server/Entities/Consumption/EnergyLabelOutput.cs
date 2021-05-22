using Library.Server.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Server.Entities.Consumption
{
    public class EnergyLabelOutput
    {
        public string Id { get; set; }
        public string SmallUserId { get; set; }
        public string EnergyLabelInputId { get; set; }
        public string EnergyClass { get; set; }
        public float Index { get; set; }
        public float kW_mpa { get; set; }
        public string TypeHouse { get; set; }
        public DateTime Data { get; set; }

        public SmallUser SmallUser { get; set; }
        public EnergyLabelInput EnergyLabelInput { get; set; }
    }
}
