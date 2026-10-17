
using System.Globalization;
using Xunit;
using kpo_vishkat.Models;
using kpo_vishkat.Services.Implementations;

namespace kpo_vishkat.Tests;

public class ReportServiceTests
{
    [Fact]
    public void TransportCountReport_ReturnsOnlyTransportCount()
    {
        var park = new Park();
        park.AddItem(new Bicycle("B-001", "Велосипед", 8));
        park.AddItem(new Bicycle("B-002", "Велосипед 2", 4));
        park.AddItem(new Helmet("H-001", "Шлем"));

        var report = new TransportCountReportService(park);

        Assert.Equal("Количество транспортных средств: 2", report.generate());
    }

    [Fact]
    public void EnergyConsumptionReport_SumsEnergyConsumers()
    {
        var park = new Park();
        park.AddItem(new ElectroScooter("S-001", "Самокат", 1.5, 7));
        park.AddItem(new ChargingStation("C-001", "Зарядная станция", 2.0));
        park.AddItem(new Bicycle("B-001", "Велосипед", 8));

        var report = new EnergyConsumptionReportService(park);

        string expected = $"Суммарное суточное энергопотребление: " + $"{3.5.ToString("F2", CultureInfo.CurrentCulture)} кВт·ч";

        Assert.Equal(expected, report.generate());
    }

    [Fact]
    public void SimplicityReport_IncludesOnlyTransportWithSimplicityAtLeastSix()
    {
        var park = new Park();
        park.AddItem(new Bicycle("B-001", "Для новичка", 6));
        park.AddItem(new Bicycle("B-002", "Для опытного", 5));

        var report = new SimplicityReportService(park);

        string result = report.generate();

        Assert.Contains("Для новичка", result);
        Assert.Contains("B-001", result);
        Assert.DoesNotContain("Для опытного", result);
        Assert.DoesNotContain("B-002", result);
    }

    [Fact]
    public void SimplicityReport_WhenNoSuitableTransport_ReturnsMessage()
    {
        var park = new Park();
        park.AddItem(new Bicycle("B-001", "Велосипед", 5));

        var report = new SimplicityReportService(park);

        Assert.Equal("Нет транспорта, подходящего для новичков.", report.generate());
    }

    [Fact]
    public void InventoryReport_IncludesNamesAndInventoryNumbers()
    {
        var park = new Park();
        park.AddItem(new Bicycle("B-001", "Городской велосипед", 8));
        park.AddItem(new Helmet("H-001", "Защитный шлем"));

        var report = new InventoryReportService(park);

        string result = report.generate();

        Assert.Contains("Городской велосипед", result);
        Assert.Contains("B-001", result);
        Assert.Contains("Защитный шлем", result);
        Assert.Contains("H-001", result);
    }

    [Fact]
    public void InventoryReport_WhenParkIsEmpty_ReturnsMessage()
    {
        var park = new Park();
        var report = new InventoryReportService(park);

        Assert.Equal("Парк пока пуст.", report.generate());
    }
}
