using Library.IdentityServer.Data;
using Library.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services.User
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthenticationContext _userContext;
        private readonly ConsumptionContext _consumptionContext;

        public UserRepository(AuthenticationContext userContext, ConsumptionContext consumptionContext)
        {
            _userContext = userContext;
            _consumptionContext = consumptionContext;
        }

        public string GetIdByName(string UserName)
        {
            if (UserName == null)
            {
                return "";
            }

            var user = _userContext.Users.FirstOrDefault(r => r.UserName.Equals(UserName));

            return user.Id;
        }

        public string GetIdConsumptionByName(string UserName)
        {
            if (UserName == null)
            {
                return "";
            }

            var consumption = _consumptionContext.IndexConsumptions.OrderBy(r => r.Id).Where(r => r.SmallUser.UserName.Equals(UserName)).Last();
            //var consumption  = _consumptionContext.IndexConsumptions.OrderBy(r => r.SmallUser.UserName.Equals(UserName)).Last();

            return consumption.IndexConsumptionId;
        }


        public string GetIdFinalConsumptionByIndexConsumption(string indexConsumptionId)
        {
            if (indexConsumptionId == null)
            {
                return "";
            }

            var consumption = _consumptionContext.FinalConsumptions.Where(x => x.IndexConsumptionId.Equals(indexConsumptionId)).OrderBy(x => x.Id).Last();

            return consumption.FinalConsumptionId;
        }

        
        public string GetIdEnergyLabelInput(string FinalConsumptionId)
        {
            var consumption = _consumptionContext.EnergyLabels.FirstOrDefault(x => x.FinalConsumptionId.Equals(FinalConsumptionId));

            return consumption.Id;
        }

        public float GetTotalConsumptionByFinalId(string id)
        {
            var consumption = _consumptionContext.FinalConsumptions.FirstOrDefault(x => x.FinalConsumptionId.Equals(id));

            return consumption.nrKw;
        }
    }
}
