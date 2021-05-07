using Library.IdentityServer.Data;
using Library.Server.Data;
using Library.Server.Entities.User;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class Program
    {
        public static async Task Main(string[] args)
        { 
            IHost webHost = CreateHostBuilder(args).Build();

            using (var scope = webHost.Services.CreateScope())
            {
                IConfiguration configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();

                AuthenticationContext authenticationContext = scope.ServiceProvider.GetRequiredService<AuthenticationContext>();
                UserContext userContext = scope.ServiceProvider.GetRequiredService<UserContext>();

                var users = new List<SmallUser>();
                foreach (var user in authenticationContext.Users)
                {
                    users.Add(new SmallUser
                    {
                        Id = user.Id,
                        UserName = user.UserName,
                        Email = user.Email
                    });
                }

                var smallUsers = userContext.SmallUser.AsNoTracking().ToList();

                var results = users.Where(u => !smallUsers.Any(s => u.Id.Equals(s.Id) && u.UserName.Equals(s.UserName)));

                foreach (var user in results)
                {
                    userContext.SmallUser.Add(user);
                }

                await userContext.SaveChangesAsync();
            }

            await webHost.RunAsync();


            CreateHostBuilder(args).Build().Run();
        }
               
   
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
