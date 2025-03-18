using CommandLine;
using ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        var arguments = Parser.Default.ParseArguments<ProgramArgumentsReadDto>(args).Value;
        if (arguments == null)
        {
            throw new Exception("[DEV] Could not parse arguments.");
        }

        Console.WriteLine($"Flavor: {arguments.Flavor}");
        Console.WriteLine($"Environment: {arguments.Environment}");
        Console.WriteLine($"Version: {arguments.Version}");
    }
}

