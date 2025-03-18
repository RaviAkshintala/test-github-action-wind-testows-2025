using CommandLine;
using ConsoleApp;

var arguments = Parser.Default.ParseArguments<ProgramArgumentsReadDto>(args)?.Value;
if (arguments == null)
{
    throw new Exception("[DEV] could not parse arguments");
}

Console.WriteLine($"flavor: {arguments.Flavor}");
Console.WriteLine($"environment: {arguments.Environment}");
Console.WriteLine($"version: {arguments.Version}");
