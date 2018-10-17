using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Camisetas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        } // End of method Main.

        public static IWebHost BuildWebHost(string[] args){
            return new WebHostBuilder()
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .ConfigureAppConfiguration((hostingContext, congig) =>
            {
                var env = hostingContext.HostingEnvironment;
                congig.AddJsonFile("appsettings.json", optional: true, 
                    reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, 
                    reloadOnChange: true);

                if(env.IsDevelopment())
                {
                    var appAssembly = 
                        Assembly.Load(new AssemblyName(env.ApplicationName));
                    if(appAssembly != null)
                    {
                        congig.AddUserSecrets(appAssembly, optional:true);
                    }
                }

                congig.AddEnvironmentVariables();

                if(args != null)
                {
                    congig.AddCommandLine(args);
                }

            })
            .ConfigureLogging((hostingContext, logging) =>
            {
                logging.AddConfiguration(
                    hostingContext.Configuration.GetSection("Logging"));
                    logging.AddConsole();
                    logging.AddDebug();
                
            })
            .UseIISIntegration()
            .UseDefaultServiceProvider(options =>
                    options.ValidateScopes = false)
            .UseStartup<Startup>()
            .Build();
        } // End of method BuildWebHost.

    } // End of class Program.
    
} // End of namespace Camisetas.