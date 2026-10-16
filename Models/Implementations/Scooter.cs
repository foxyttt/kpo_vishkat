using kpo_vishkat.Models;

namespace kpo_vishkat.Models;

public sealed class Scooter : iTransport, iInventoryItem
{
    public string InventoryNumber { get; }
    public string Name { get; }
    public int Simplicity { get; }

    public Scooter(string inventoryNumber, string name, int simplicity)
    {
        InventoryNumber = inventoryNumber;
        Name = name;
        Simplicity = simplicity;
    }
}