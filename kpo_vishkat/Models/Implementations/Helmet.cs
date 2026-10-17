using kpo_vishkat.Models;

namespace kpo_vishkat.Models;

public sealed class Helmet : iInventoryItem
{
    public string InventoryNumber { get; }
    public string Name { get; }

    public Helmet(string inventoryNumber, string name)
    {
        InventoryNumber = inventoryNumber;
        Name = name;
    }
}