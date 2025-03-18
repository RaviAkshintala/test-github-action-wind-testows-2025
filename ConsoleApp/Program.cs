using System;
using CommandLine;

class Program
{
    public class Options
    {
        [Option('f', "flavor", Required = true, HelpText = "Which flavor of the artifact should be created by the setup.")]
        public string Flavor { get; set; }

        [Option('e', "environment", Required = true, HelpText = "Whether the final installed artifact should point to staging or production apis, and whether the final artifact should be uploaded to staging or production backoffice.")]
        public string Environment { get; set; }

        [Option('v', "version", Required = true, HelpText = "The sem-ver of the artifact. Will also be appended to the setup filename.")]
        public string Version { get; set; }
    }

    static void Main(string[] args)
    {
        Parser.Default.ParseArguments<Options>(args)
            .WithParsed<Options>(opts => RunOptionsAndReturnExitCode(opts))
            .WithNotParsed<Options>((errs) => HandleParseError(errs));
    }

    static void RunOptionsAndReturnExitCode(Options opts)
    {
        Console.WriteLine($"flavor: {opts.Flavor}");
        Console.WriteLine($"environment: {opts.Environment}");
        Console.WriteLine($"version: {opts.Version}");
    }

    static void HandleParseError(IEnumerable<Error> errs)
    {
        foreach (var err in errs)
        {
            Console.WriteLine(err.ToString());
        }
        throw new Exception("[DEV] could not parse arguments");
    }
}
