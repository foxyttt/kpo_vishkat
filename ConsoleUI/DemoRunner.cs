using kpo_vishkat.Models;
using kpo_vishkat.Services;
using kpo_vishkat.Services.Implementations;

namespace kpo_vishkat.ConsoleUI;

public class DemoRunner
{
    private readonly ParkReplenishment _parkReplenishment;
    private readonly IEnumerable<iReportService> _reports;

    public DemoRunner(
        ParkReplenishment parkReplenishment,
        IEnumerable<iReportService> reports)
    {
        _parkReplenishment = parkReplenishment;
        _reports = reports;
    }

    public void Run()
    {
        Console.WriteLine("=== Демонстрация ВышКат ===\n");

        Console.WriteLine("Добавление транспорта:");

        AddTransport(new Bicycle("BC-001", "Городской велосипед", 8));

        AddTransport(new ElectroScooter("ES-001", "Электросамокат", 1.5, 7));

        AddTransport(new Bicycle("BC-002", "Спортивный велосипед", 4));

        Console.WriteLine("\nДобавление вещей:");

        _parkReplenishment.AddItem(new Helmet("HM-001", "Защитный шлем"));
        Console.WriteLine("Добавлен защитный шлем.");

        _parkReplenishment.AddItem(new ChargingStation(
            "CS-001", "Зарядная станция", 2.0));
        Console.WriteLine("Добавлена зарядная станция.");

        Console.WriteLine("\n=== Отчёты ===");

        foreach (var report in _reports)
        {
            Console.WriteLine($"\n--- {report.Name} ---");
            Console.WriteLine(report.generate());
        }
    }

    private void AddTransport(iTransport transport)
    {
        bool accepted = _parkReplenishment.TryAddTransport(transport);

        Console.WriteLine(
            $"{transport.Name}: " +
            (accepted ? "принят." : "отклонён."));
    }
}