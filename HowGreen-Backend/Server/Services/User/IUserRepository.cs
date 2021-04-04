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
    }
}
