using System;
using ComplementDrugSearch.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ComplementDrugSearch
{
    /// <summary>
    /// Represents the main class of the application.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Initializes the application.
        /// </summary>
        /// <param name="args">Represents the parameters for the application.</param>
        static void Main(string[] args)
        {
            // Create the host and run it.
            using var host = CreateHostBuilder(args).Build();
            // Try to run it.
            try
            {
                host.Run();
            }
            catch (OperationCanceledException)
            {

            }
        }

        /// <summary>
        /// Creates a host builder with the given parameters.
        /// </summary>
        /// <param name="args">Represents the parameters for the web host builder.</param>
        /// <returns>Returns a new host containing the given hosted service.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            // Return a hosted service with the given options.
            return Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.SetMinimumLevel(LogLevel.Information);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<ApplicationRunService>();
                });
        }
    }
}
