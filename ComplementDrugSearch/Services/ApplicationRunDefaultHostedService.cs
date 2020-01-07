using ComplementDrugSearch.Models;
using MathNet.Numerics.LinearAlgebra;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ComplementDrugSearch.Services
{
    /// <summary>
    /// Represents the hosted service corresponding to an application run.
    /// </summary>
    public class ApplicationRunDefaultHostedService : BackgroundService
    {
        /// <summary>
        /// Represents the configuration.
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Represents the logger.
        /// </summary>
        private readonly ILogger<ApplicationRunCliHostedService> _logger;

        /// <summary>
        /// Represents the host application lifetime.
        /// </summary>
        private readonly IHostApplicationLifetime _hostApplicationLifetime;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="arguments">Represents the program arguments.</param>
        /// <param name="logger">Represents the logger.</param>
        public ApplicationRunDefaultHostedService(IConfiguration configuration, ILogger<ApplicationRunCliHostedService> logger, IHostApplicationLifetime hostApplicationLifetime)
        {
            _configuration = configuration;
            _logger = logger;
            _hostApplicationLifetime = hostApplicationLifetime;
        }

        /// <summary>
        /// Launches the application execution.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token corresponding to the task.</param>
        /// <returns>A runnable task.</returns>
        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            // Wait for a completed task, in order to not get a warning about having an async method.
            await Task.CompletedTask;
            // Log a message.
            _logger.LogInformation(string.Concat(
                "\n\tWelcome to the ComplimentDrugSearch application!",
                "\n\t",
                "\n\t---",
                "\n\t",
                "\n\tAll argument names and values are case-sensitive. The following arguments can be provided:",
                "\n\t--Mode\tUse this argument to apecify the mode in which the application will run. The possible values are \"Cli\" (the application will run in the command-line) and \"Help\" (the application will display this help message). The default value is \"Cli\".",
                "\n\tArguments for \"Cli\" mode:",
                "\n\t--Interactions\tUse this argument to specify the path to the file containing the protein-protein interactions. Each interaction should be on a new line, with its elements separated by semicolons. Each interaction should contain the source protein, the target protein, and the type (\"-1\" for a down-regulating interaction or equivalent, \"1\" for an up-regulating interaction or equivalent, or \"0\" otherwise). This argument does not have a default value.",
                "\n\t--Drugs\tUse this argument to specify the path to the file containing the possible drugs. Each drug should be on a new line, with its elements separated by semicolons. Each drug should contain the drug name, the corresponding drug-target, and the type (\"-1\" for a drug that down-regulates its drug-target, \"1\" for a drug that up-regulates its drug-target, or \"0\" otherwise). Only the drugs with drug-targets appearing in the interactions will be considered. This argument does not have a default value.",
                "\n\t--DiseaseEssentialProteins\t(optional) Use this argument to specify the path to the file containing the disease-essential proteins. Each protein should be on a new line. This argument does not have a default value and can be omitted if healthy-essential proteins are provided.",
                "\n\t--HealthyEssentialProteins\t(optional) Use this argument to specify the path to the file containing the disease-essential proteins. Each protein should be on a new line. This argument does not have a default value and can be omitted if disease-essential proteins are provided.",
                "\n\t--Initial\tUse this argument to specify the name of the initial drug or drug-target. This argument does not have a default value.",
                "\n\t--MaximumPath\t(optional) Use this argument to specify the maximum length of the path between the drug-targets and the essential proteins. The default value is \"3\".",
                "\n\t--NumberOfSolutions\t(optional) Use this argument to specify the maximum number of complementing drugs to be returned. The default value is \"10\".",
                "\n\t\t--Output\t(optional) Use this argument to specify the path to the output file where the solutions of the analysis will be written. Writing permission is needed for the corresponding folder. If a file with the same name already exists, it will be automatically overwritten. The default value is the name of the file containing the interactions, followed by the name of the initial drug, the name of its drug-target, and the current date and time.",
                "\n\tExamples of posible usage:",
                "\n\t--Mode \"Help\"",
                "\n\t--Mode \"Cli\" --Interactions \"Path/To/FileContainingInteractions.extension\" --Drugs \"Path/To/FileContainingDrugs.extension\" --DiseaseEssentialProteins \"Path/To/FileContainingDiseaseEssentialProteins.extension\" --Initial \"InitialDrugName\"",
                "\n\t--Mode \"Cli\" --Interactions \"Path/To/FileContainingInteractions.extension\" --Drugs \"Path/To/FileContainingDrugs.extension\" --DiseaseEssentialProteins \"Path/To/FileContainingDiseaseEssentialProteins.extension\" --HealthyEssentialProteins \"Path/To/FileContainingHealthyEssentialProteins.extension\" --Initial \"InitialDrugName\" --MaximumPath \"3\" --NumberOfSolutions \"10\" --Output \"Path/To/OutputFile.extension\"",
                "\n\t"));
            // Get the mode in which to run the application.
            var mode = _configuration["Mode"];
            // Check if the mode is not valid.
            if (mode != "Help")
            {
                // Log an error.
                _logger.LogError($"The provided mode \"{mode}\" for running the application is not valid.");
                // Stop the application.
                _hostApplicationLifetime.StopApplication();
                // Return a successfully completed task.
                return;
            }
            // Stop the application.
            _hostApplicationLifetime.StopApplication();
            // Return a successfully completed task.
            return;
        }
    }
}
