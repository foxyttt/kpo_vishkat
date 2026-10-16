using kpo_vishkat.ConsoleUI;
using kpo_vishkat.Models;
using kpo_vishkat.Services;
using kpo_vishkat.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace kpo_vishkat;

internal class Program
{
    private static int Main(string[] args)
    {
        var services = new ServiceCollection();

        services.AddSingleton<Park>();
        services.AddSingleton<iServiceCenter, ServiceCenter>();
        services.AddSingleton<ParkReplenishment>();

        services.AddSingleton<iReportService, TransportCountReportService>();
        services.AddSingleton<iReportService, EnergyConsumptionReportService>();
        services.AddSingleton<iReportService, BeginnerFriendlyReportService>();
        services.AddSingleton<iReportService, InventoryReportService>();

        services.AddSingleton<ConsoleApplication>();
        services.AddSingleton<DemoRunner>();

        using var provider = services.BuildServiceProvider();

        if (args.Length == 1 &&
            string.Equals(args[0], "--demo", StringComparison.OrdinalIgnoreCase))
        {
            provider.GetRequiredService<DemoRunner>().Run();
            return 0;
        }

        if (args.Length > 0)
        {
            Console.WriteLine("Неизвестные аргументы.");
            Console.WriteLine("Использование: kpo_vishkat [--demo]");
            return 1;
        }

        provider.GetRequiredService<ConsoleApplication>().Run();
        return 0;
    }
}