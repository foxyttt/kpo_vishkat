using kpo_vishkat.Models;

namespace kpo_vishkat.Services;

public class FleetService
{
    private readonly IServiceCenter _serviceCenter;
    private readonly Park _park;

    public FleetService(IServiceCenter serviceCenter, Park park)
    {
        _serviceCenter = serviceCenter;
        _park = park;
    }

    public bool TryAddTransport(ITransport transport)
    {
        if (!_serviceCenter.Accept(transport))
        {
            return false;
        }

        _park.AddItem(transport);

        return true;
    }

    public void AddItem(IInventoryItem item)
    {
        _park.AddItem(item);
    }
}