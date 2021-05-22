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

            var consumption  = _consumptionContext.FinalConsumptions.FirstOrDefault(r => r.SmallUser.UserName.Equals(UserName));

            return consumption.IndexConsumptionId;
        }
    }
}
