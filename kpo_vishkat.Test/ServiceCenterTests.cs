
using Xunit;
using kpo_vishkat.Models;
using kpo_vishkat.Services;
using kpo_vishkat.Services.Implementations;

namespace kpo_vishkat.Tests;

public class ServiceCenterTests
{
    [Fact]
    public void AlwaysAcceptServiceCenter_AcceptsTransport()
    {
        var service = new AlwaysAcceptServiceCenter();
        var bicycle = new Bicycle("B-001", "Велосипед", 2);

        Assert.True(service.Accept(bicycle));
    }

    [Fact]
    public void AlwaysDeclineServiceCenter_DeclinesTransport()
    {
        var service = new AlwaysDeclineServiceCenter();
        var bicycle = new Bicycle("B-002", "Велосипед", 8);

        Assert.False(service.Accept(bicycle));
    }

    [Theory]
    [InlineData(2, false)]
    [InlineData(3, true)]
    [InlineData(6, true)]
    public void SimplicityDrivenServiceCenter_ChecksSimplicity(int simplicity, bool expected)
    {
        var service = new SimplicityDrivenServiceCenter();
        var bicycle = new Bicycle("B-003", "Велосипед", simplicity);

        Assert.Equal(expected, service.Accept(bicycle));
    }

    [Fact]
    public void ServiceCenters_ThrowWhenTransportIsNull()
    {
        Assert.Throws<ArgumentNullException>(
            () => new AlwaysAcceptServiceCenter().Accept(null!));

        Assert.Throws<ArgumentNullException>(
            () => new AlwaysDeclineServiceCenter().Accept(null!));

        Assert.Throws<ArgumentNullException>(
            () => new SimplicityDrivenServiceCenter().Accept(null!));
    }

    [Fact]
    public void TryAddTransport_WhenAccepted_AddsTransportToPark()
    {
        var park = new Park();
        var replenishment = new ParkReplenishment(new AlwaysAcceptServiceCenter(), park);
        var bicycle = new Bicycle("B-010", "Велосипед", 7);

        bool result = replenishment.TryAddTransport(bicycle);

        Assert.True(result);
        Assert.Contains(bicycle, park.Items);
    }

    [Fact]
    public void TryAddTransport_WhenDeclined_DoesNotAddTransport()
    {
        var park = new Park();
        var replenishment = new ParkReplenishment(new AlwaysDeclineServiceCenter(), park);
        var bicycle = new Bicycle("B-011", "Велосипед", 7);

        bool result = replenishment.TryAddTransport(bicycle);

        Assert.False(result);
        Assert.Empty(park.Items);
    }

    [Fact]
    public void TryAddTransport_WithSimplicityBelowThree_IsDeclined()
    {
        var park = new Park();
        var replenishment = new ParkReplenishment(new SimplicityDrivenServiceCenter(), park);
        var bicycle = new Bicycle("B-012", "Велосипед", 2);

        bool result = replenishment.TryAddTransport(bicycle);

        Assert.False(result);
        Assert.Empty(park.Items);
    }
}
