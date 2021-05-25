using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services.User
{
    public interface IUserRepository
    {
        public string GetIdByName(string UserName);
        public string GetIdConsumptionByName(string UserName);
        public string GetIdFinalConsumptionByName(string UserName);
        public float GetTotalConsumptionByFinalId(string id);
        public string GetIdEnergyLabelInput(string FinalConsumptionId);
    }
}
