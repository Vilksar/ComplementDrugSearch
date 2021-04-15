using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace ComplementDrugSearch.Services
{
    /// <summary>
    /// Represents the hosted service corresponding to an application run.
    /// </summary>
    public class DefaultHostedService : BackgroundService
    {
        /// <summary>
        /// Represents the configuration.
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Represents the logger.
        /// </summary>
        private readonly ILogger<DefaultHostedService> _logger;

        /// <summary>
        /// Represents the host application lifetime.
        /// </summary>
        private readonly IHostApplicationLifetime _hostApplicationLifetime;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="configuration">Represents the configuration.</param>
        /// <param name="logger">Represents the logger.</param>
        /// <param name="hostApplicationLifetime">Represents the host application lifetime.</param>
        public DefaultHostedService(IConfiguration configuration, ILogger<DefaultHostedService> logger, IHostApplicationLifetime hostApplicationLifetime)
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
            // Get the parameters from the configuration.
            var mode = _configuration["Mode"];
            // Log a message.
            _logger.LogInformation(string.Concat(
                "\n\tWelcome to the ComplementDrugSearch application!",
                "\n\t",
                "\n\t---",
                "\n\t",
                "\n\tAll argument names and values are case-sensitive. The following arguments can be provided:",
                "\n\t--Mode\tUse this argument to apecify the mode in which the application will run. The possible values are \"Drug\", \"Proteins\" (the application will run in the command-line) and \"Help\" (the application will display this help message). The default value is \"Help\".",
                "\n\tArguments for \"Drug\" mode:",
                "\n\t--Interactions\tUse this argument to specify the path to the file containing the protein-protein interactions. Each interaction should be on a new line, with its elements separated by semicolons. Each interaction should contain the source protein, the target protein, and the type (\"-1\" for a down-regulating interaction or equivalent, \"1\" for an up-regulating interaction or equivalent, or \"0\" otherwise). This argument does not have a default value.",
                "\n\t--Drugs\tUse this argument to specify the path to the file containing the possible drugs. Each drug should be on a new line, with its elements separated by semicolons. Each drug should contain the drug name, the corresponding drug-target, and the type (\"-1\" for a drug that down-regulates its drug-target, \"1\" for a drug that up-regulates its drug-target, or \"0\" otherwise). Only the drugs with drug-targets appearing in the interactions will be considered. This argument does not have a default value.",
                "\n\t--DiseaseEssentialProteins\t(optional) Use this argument to specify the path to the file containing the disease-essential proteins. Each protein should be on a new line. This argument does not have a default value and can be omitted if healthy-essential proteins are provided.",
                "\n\t--HealthyEssentialProteins\t(optional) Use this argument to specify the path to the file containing the healthy-essential proteins. Each protein should be on a new line. This argument does not have a default value and can be omitted if disease-essential proteins are provided.",
                "\n\t--Initial\tUse this argument to specify the name of the initial drug or drug-target. This argument does not have a default value.",
                "\n\t--MaximumPath\t(optional) Use this argument to specify the maximum length of the path between the drug-targets and the essential proteins. The default value is \"3\".",
                "\n\t--NumberOfSolutions\t(optional) Use this argument to specify the maximum number of complementing drugs to be returned. The default value is \"10\".",
                "\n\t--Output\t(optional) Use this argument to specify the path to the output file where the results will be written. Writing permission is needed for the corresponding directory. If a file with the same name already exists, it will be automatically overwritten. The default value is the name of the file containing the interactions, followed by the name of the initial drug, the name of its drug-target, and the current date and time.",
                "\n\tArguments for \"Proteins\" mode:",
                "\n\t--Interactions\tUse this argument to specify the path to the file containing the protein-protein interactions. Each interaction should be on a new line, with its elements separated by semicolons. Each interaction should contain the source protein, the target protein, and the type (\"-1\" for a down-regulating interaction or equivalent, \"1\" for an up-regulating interaction or equivalent, or \"0\" otherwise). This argument does not have a default value.",
                "\n\t--Drugs\tUse this argument to specify the path to the file containing the possible drugs. Each drug should be on a new line, with its elements separated by semicolons. Each drug should contain the drug name, the corresponding drug-target, and the type (\"-1\" for a drug that down-regulates its drug-target, \"1\" for a drug that up-regulates its drug-target, or \"0\" otherwise). Only the drugs with drug-targets appearing in the interactions will be considered. This argument does not have a default value.",
                "\n\t--DiseaseEssentialProteins\t(optional) Use this argument to specify the path to the file containing the disease-essential proteins. Each protein should be on a new line. This argument does not have a default value and can be omitted if healthy-essential proteins are provided.",
                "\n\t--HealthyEssentialProteins\t(optional) Use this argument to specify the path to the file containing the healthy-essential proteins. Each protein should be on a new line. This argument does not have a default value and can be omitted if disease-essential proteins are provided.",
                "\n\t--Initial\tUse this argument to specify the path to the file containing the initial proteins. Each protein should be on a new line. This argument does not have a default value.",
                "\n\t--MaximumPath\t(optional) Use this argument to specify the maximum length of the path between the drug-targets and the essential proteins. The default value is \"3\".",
                "\n\t--NumberOfSolutions\t(optional) Use this argument to specify the maximum number of complementing drugs to be returned. The default value is \"10\".",
                "\n\t--Output\t(optional) Use this argument to specify the path to the output file where the results will be written. Writing permission is needed for the corresponding directory. If a file with the same name already exists, it will be automatically overwritten. The default value is the name of the file containing the interactions, followed by the name of the file containing the initial proteins, and the current date and time.",
                "\n\t",
                "\n\t---",
                "\n\t",
                "\n\tExamples of posible usage:",
                "\n\t--Mode \"Help\"",
                "\n\t--Mode \"Drug\" --Interactions \"Path/To/FileContainingInteractions.extension\" --Drugs \"Path/To/FileContainingDrugs.extension\" --DiseaseEssentialProteins \"Path/To/FileContainingDiseaseEssentialProteins.extension\" --Initial \"InitialDrugName\"",
                "\n\t--Mode \"Drug\" --Interactions \"Path/To/FileContainingInteractions.extension\" --Drugs \"Path/To/FileContainingDrugs.extension\" --DiseaseEssentialProteins \"Path/To/FileContainingDiseaseEssentialProteins.extension\" --HealthyEssentialProteins \"Path/To/FileContainingHealthyEssentialProteins.extension\" --Initial \"InitialDrugName\" --MaximumPath \"3\" --NumberOfSolutions \"10\" --Output \"Path/To/OutputFile.extension\"",
                "\n\t--Mode \"Proteins\" --Interactions \"Path/To/FileContainingInteractions.extension\" --Drugs \"Path/To/FileContainingDrugs.extension\" --DiseaseEssentialProteins \"Path/To/FileContainingDiseaseEssentialProteins.extension\" --Initial \"Path/To/FileContainingInitialProteins.extension\"",
                "\n\t--Mode \"Proteins\" --Interactions \"Path/To/FileContainingInteractions.extension\" --Drugs \"Path/To/FileContainingDrugs.extension\" --DiseaseEssentialProteins \"Path/To/FileContainingDiseaseEssentialProteins.extension\" --HealthyEssentialProteins \"Path/To/FileContainingHealthyEssentialProteins.extension\" --Initial \"Path/To/FileContainingInitialProteins.extension\" --MaximumPath \"3\" --NumberOfSolutions \"10\" --Output \"Path/To/OutputFile.extension\"",
                "\n\t"));
            // Check if the mode is not valid.
            if (!string.IsNullOrEmpty(mode) && mode != "Help")
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
