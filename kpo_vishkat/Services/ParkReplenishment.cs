using kpo_vishkat.Models;

namespace kpo_vishkat.Services;

public class ParkReplenishment
{
    private readonly iServiceCenter _serviceCenter;
    private readonly Park _park;

    public ParkReplenishment(iServiceCenter serviceCenter, Park park)
    {
        _serviceCenter = serviceCenter;
        _park = park;
    }

    public bool TryAddTransport(iTransport transport)
    {
        if (!_serviceCenter.Accept(transport))
        {
            return false;
        }

        _park.AddItem(transport);

        return true;
    }

    public void AddItem(iInventoryItem item)
    {
        _park.AddItem(item);
    }
}