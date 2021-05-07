using Library.IdentityServer.Data;
using Library.Server.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Server.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Server", Version = "v1" });
            });

            services.AddDbContext<ConsumptionContext>
            (
                options => options.UseSqlServer(Configuration.GetConnectionString("ServerConnection"))
            );
            services.AddDbContext<ContactContext>
            (
                options => options.UseSqlServer(Configuration.GetConnectionString("ServerConnection"))
            );
            services.AddDbContext<PaymentContext>
            (
                options => options.UseSqlServer(Configuration.GetConnectionString("ServerConnection"))
            );
            services.AddDbContext<UserContext>
            (
                options => options.UseSqlServer(Configuration.GetConnectionString("ServerConnection"))
            );

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddDbContext<AuthenticationContext>
            (
                options => options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection"))
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Apply pending migrations
            InitializeDatabase(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Server v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var userContext = serviceScope.ServiceProvider.GetRequiredService<UserContext>();
                userContext.Database.Migrate();

                /*var consumptionContext = serviceScope.ServiceProvider.GetRequiredService<ConsumptionContext>();
                consumptionContext.Database.Migrate();

                var contactContext = serviceScope.ServiceProvider.GetRequiredService<ContactContext>();
                contactContext.Database.Migrate();

                var paymentContext = serviceScope.ServiceProvider.GetRequiredService<PaymentContext>();
                paymentContext.Database.Migrate();*/
            }
        }
    }
}
