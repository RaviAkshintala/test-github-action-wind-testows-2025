using CommandLine;
using System;

namespace ConsoleApp
{
    // Define the DTO to hold the parsed command line arguments
    public class ProgramArgumentsReadDto
    {
        [Option('f', "flavor", Required = true, HelpText = "Which flavor of the artifact should be created.")]
        public string Flavor { get; set; }

        [Option('e', "environment", Required = true, HelpText = "Environment setting for the artifact.")]
        public string Environment { get; set; }

        [Option('v', "version", Required = true, HelpText = "The version of the artifact.")]
        public string Version { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Parse the arguments using the CommandLine parser
            var result = Parser.Default.ParseArguments<ProgramArgumentsReadDto>(args);

            // Check if the arguments were parsed successfully
            result.WithParsed(arguments =>
            {
                // If parsed successfully, display the arguments
                Console.WriteLine($"Flavor: {arguments.Flavor}");
                Console.WriteLine($"Environment: {arguments.Environment}");
                Console.WriteLine($"Version: {arguments.Version}");
            })
            .WithNotParsed(errors =>
            {
                // If parsing fails, display an error message
                Console.WriteLine("[DEV] Could not parse arguments.");
                Environment.Exit(1); // Exit with error code
            });
        }
    }
}

