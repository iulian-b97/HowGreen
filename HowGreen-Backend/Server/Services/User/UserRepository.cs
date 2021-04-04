using Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services.User
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _userContext;
        private readonly ConsumptionContext _consumptionContext;

        public UserRepository(UserContext userContext, ConsumptionContext consumptionContext)
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

            var user = _userContext.SmallUser.FirstOrDefault(r => r.UserName.Equals(UserName));

            return user.Id;
        }

        public string GetIdConsumptionByName(string UserName)
        {
            if (UserName == null)
            {
                return "";
            }

            var consumption  = _consumptionContext.FinalConsumption.FirstOrDefault(r => r.SmallUser.UserName.Equals(UserName));

            return consumption.Id;
        }
    }
}
