using ComplementDrugSearch.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

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
            // Get the current command-line arguments configuration.
            var configuration = new ConfigurationBuilder().AddCommandLine(args).Build();
            // Get the mode in which to run the application.
            var mode = configuration["Mode"] ?? "Cli";
            // Get the host to run based on the command-line arguments and build it.
            using var host = (mode == "Cli" ? CreateCliHostBuilder(args) : CreateDefaultHostBuilder(args)).Build();
            // Try to run the application host.
            try
            {
                host.Run();
            }
            catch (OperationCanceledException)
            {

            }
        }

        /// <summary>
        /// Creates a CLI host builder with the given parameters.
        /// </summary>
        /// <param name="args">Represents the parameters for the web host builder.</param>
        /// <returns>Returns a new host containing the given hosted service.</returns>
        public static IHostBuilder CreateCliHostBuilder(string[] args)
        {
            // Return a hosted service with the given options.
            return Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.SetMinimumLevel(LogLevel.Information);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<ApplicationRunCliHostedService>();
                });
        }

        /// <summary>
        /// Creates a default host builder with the given parameters.
        /// </summary>
        /// <param name="args">Represents the parameters for the web host builder.</param>
        /// <returns>Returns a new host containing the given hosted service.</returns>
        public static IHostBuilder CreateDefaultHostBuilder(string[] args)
        {
            // Return a host with the given options.
            return Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.SetMinimumLevel(LogLevel.Information);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<ApplicationRunDefaultHostedService>();
                });
        }
    }
}
