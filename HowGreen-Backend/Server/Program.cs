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
using Server;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}

/*
string DestinationCs = "server=.;database=HowGreenDB;Trusted_Connection=true;MultipleActiveResultSets=True;";
string SourceCs = "server=.;database=UserDB;Trusted_Connection=true;MultipleActiveResultSets=True;";

DeleteAllRowsTable(DestinationCs);
BulkCopyTable(DestinationCs, SourceCs);
*/

/*
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

    foreach(var user in results)
    {
        userContext.SmallUser.Add(user);
    }

    await userContext.SaveChangesAsync();
}

await webHost.RunAsync();


CreateHostBuilder(args).Build().Run();
}

private static void BulkCopyTable(string DestinationCs, string SourceCs)
{
using (SqlConnection SourceCon = new SqlConnection(SourceCs))
{
    SqlCommand cmd = new SqlCommand("SELECT * FROM AspNetUsers", SourceCon);
    SourceCon.Open();

    using (SqlDataReader rdr = cmd.ExecuteReader())
    {
        using (SqlConnection DestinationCon = new SqlConnection(DestinationCs))
        {
            using (SqlBulkCopy bc = new SqlBulkCopy(DestinationCon))
            {
                bc.DestinationTableName = "Users";
                DestinationCon.Open();

                // Set up the column mappings by name.
                SqlBulkCopyColumnMapping mapID =
                    new SqlBulkCopyColumnMapping("Id", "Id");
                bc.ColumnMappings.Add(mapID);

                SqlBulkCopyColumnMapping mapUserName =
                    new SqlBulkCopyColumnMapping("UserName", "UserName");
                bc.ColumnMappings.Add(mapUserName);

                SqlBulkCopyColumnMapping mapEmail =
                    new SqlBulkCopyColumnMapping("Email", "Email");
                bc.ColumnMappings.Add(mapEmail);

                bc.WriteToServer(rdr);
            }
        }
    }
}
}

private static void DeleteAllRowsTable(string DestinationCs)
{
using (SqlConnection DestinationCon = new SqlConnection(DestinationCs))
{
    SqlCommand cmd = new SqlCommand("DELETE FROM Users", DestinationCon);
    DestinationCon.Open();

    using (SqlDataReader rdr = cmd.ExecuteReader())
    {

    }
}


public static IHostBuilder CreateHostBuilder(string[] args) =>
Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseStartup<Startup>();
    });

}*/


