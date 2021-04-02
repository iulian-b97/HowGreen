using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _userContext;

        public UserController(UserContext userContext)
        {
            _userContext = userContext;
        }

        /*
        [HttpPost]
        [Route("AddUser")]
        public async Task<ActionResult<IEnumerable<SmallUser>>> AddUser(SmallUser smallUser)
        {
            var smallUsers = new SmallUser
            {
                FullName = smallUser.FullName,
                UserName = smallUser.UserName,
                Email = smallUser.Email
            };

            await _userContext.Users.AddAsync(smallUsers);
            await _userContext.SaveChangesAsync();

            return NoContent();
        }
        */
    }
}
