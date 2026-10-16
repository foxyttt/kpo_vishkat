using Microsoft.Extensions.DependencyInjection;
using kpo_vishkat.Models;
using kpo_vishkat.Services;
using kpo_vishkat.Services.Implementations;

namespace kpo_vishkat;

internal class Program
{
    private static void Main(string[] args)
    {
        // 1. Настраиваем DI-контейнер.
        var services = new ServiceCollection();

        services.AddSingleton<Park>();
        services.AddSingleton<IServiceCenter, ServiceCenter>();
        services.AddSingleton<ParkReplenishment>();

        using var serviceProvider = services.BuildServiceProvider();

        var park = serviceProvider.GetRequiredService<Park>();
        var parkReplenishment = serviceProvider.GetRequiredService<FleetService>();

        var scooter = new ElectroScooter("SC-001", "Электросамокат Xiaomi", 8, 1.5);

        var helmet = new Helmet("HM-001", "Защитный шлем");

        bool accepted = parkReplenishment.TryAddTransport(scooter);

        Console.WriteLine(accepted ? $"Транспорт {scooter.Name} принят в парк." : $"Транспорт {scooter.Name} не прошёл техосмотр.");

        fleetService.AddItem(helmet);

        Console.WriteLine($"Вещь {helmet.Name} добавлена на баланс.");

        Console.WriteLine("\nИнвентаризация:");

        foreach (var item in park.Items)
        {
            Console.WriteLine($"{item.Name} | Инвентарный номер: {item.InventoryNumber}");
        }
    }
}