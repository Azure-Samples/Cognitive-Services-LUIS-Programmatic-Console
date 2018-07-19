namespace Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring.Sample
{
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring;
    using Microsoft.Azure.CognitiveServices.LUIS.Authoring.Sample;
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

            ProgrammaticKey = Configuration["LUIS.AuthoringKey"];

            if (string.IsNullOrWhiteSpace(ProgrammaticKey))
            {
                throw new ArgumentException("Missing \"LUIS.AuthoringKey\" in appsettings.json");
            }
        }
    }
}
