
using System;
using System.Linq;
using Xunit;
using kpo_vishkat.Models;

namespace kpo_vishkat.Tests;

public class ParkTests
{
    [Fact]
    public void AddItem_AddsItemToPark()
    {
        var park = new Park();
        var helmet = new Helmet("H-001", "Защитный шлем");

        park.AddItem(helmet);

        Assert.Single(park.Items);
        Assert.Contains(helmet, park.Items);
    }

    [Fact]
    public void AddItem_Null_ThrowsArgumentNullException()
    {
        var park = new Park();

        Assert.Throws<ArgumentNullException>(() => park.AddItem(null!));
    }

    [Fact]
    public void AddItem_DuplicateInventoryNumber_ThrowsInvalidOperationException()
    {
        var park = new Park();
        park.AddItem(new Helmet("H-001", "Первый шлем"));

        var duplicate = new Helmet("H-001", "Второй шлем");

        Assert.Throws<InvalidOperationException>(() => park.AddItem(duplicate));

        Assert.Single(park.Items);
    }

    [Fact]
    public void Transports_ContainsOnlyTransportItems()
    {
        var park = new Park();
        var bicycle = new Bicycle("B-001", "Велосипед", 7);
        var helmet = new Helmet("H-001", "Шлем");

        park.AddItem(bicycle);
        park.AddItem(helmet);

        Assert.Single(park.Transports);
        Assert.Contains(bicycle, park.Transports);
    }

    [Fact]
    public void EnergyConsumers_ContainsOnlyEnergyConsumers()
    {
        var park = new Park();
        var scooter = new ElectroScooter("S-001", "Электросамокат", 1.5, 7);
        var bicycle = new Bicycle("B-001", "Велосипед", 8);

        park.AddItem(scooter);
        park.AddItem(bicycle);

        Assert.Single(park.EnergyConsumers);
        Assert.Contains(scooter, park.EnergyConsumers);
    }
}
