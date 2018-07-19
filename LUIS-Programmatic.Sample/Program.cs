namespace Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic.Sample
{
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring;
    using Microsoft.Azure.CognitiveServices.LUIS.Programmatic.Sample;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.IO;

    class Program
    {
        public static IConfigurationRoot Configuration { get; set; }

        private static string ProgrammaticKey;

        static void Main(string[] args)
        {
            ReadConfiguration();

            var client = new LUISAuthoringClient(new Uri("https://westus.api.cognitive.microsoft.com/luis/api/v2.0/"), new ApiKeyServiceClientCredentials(ProgrammaticKey));
            var program = new BaseProgram(client, ProgrammaticKey);

            program.Run();
        }

        static void ReadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            ProgrammaticKey = Configuration["LUIS.ProgrammaticKey"];

            if (string.IsNullOrWhiteSpace(ProgrammaticKey))
            {
                throw new ArgumentException("Missing \"LUIS.ProgrammaticKey\" in appsettings.json");
            }
        }
    }
}
