using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Videos.Database;

namespace Videos.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
			var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
			var host = CreateHostBuilder(args).Build();

            try
            {
				logger.Debug("init main");

				using (var scope = host.Services.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                    context.Database.EnsureCreated();
                    if (!context.Users.Any())
                    {
                        var adminUser = new IdentityUser
                        {
                            UserName = "Admin",

                        };

                        var managerUser = new IdentityUser
                        {
                            UserName = "Manager",
                        };

                        userManager.CreateAsync(adminUser, "password").GetAwaiter().GetResult();
                        userManager.CreateAsync(managerUser, "password").GetAwaiter().GetResult();

                        var adminClaim = new Claim("Role", "Admin");
                        var managerClaim = new Claim("Role", "Manager");

                        userManager.AddClaimAsync(adminUser, adminClaim).GetAwaiter().GetResult();
                        userManager.AddClaimAsync(managerUser, managerClaim).GetAwaiter().GetResult();
                    }
                }
            }
            catch (Exception e)
            {
				//NLog: catch setup errors
				logger.Error(e, "Stopped program because of exception");
				Console.WriteLine(e.Message.ToString());
            }
            finally
            {
				host.Run();
				NLog.LogManager.Shutdown();
			}
		}

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
			    .ConfigureLogging(logging =>
			    {
				    logging.ClearProviders();
				    logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
			    })
		        .UseNLog();  // NLog: Setup NLog for Dependency injection
	}
}
