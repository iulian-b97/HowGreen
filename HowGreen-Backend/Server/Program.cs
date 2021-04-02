using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string DestinationCs = "server=.;database=HowGreenDB;Trusted_Connection=true;MultipleActiveResultSets=True;";
            string SourceCs = "server=.;database=UserDB;Trusted_Connection=true;MultipleActiveResultSets=True;";



            using (SqlConnection SourceCon = new SqlConnection(SourceCs))
            {
                SqlCommand cmd = new SqlCommand("Select * From AspNetUsers", SourceCon);
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
