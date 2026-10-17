using kpo_vishkat.Models;

namespace kpo_vishkat.Models;

public sealed class Bicycle : iTransport, iInventoryItem
{
    public string InventoryNumber {  get; }
    public string Name { get; }
    public int Simplicity {  get; }

    public Bicycle(string inventoryNumber, string name, int simplicity)
    {
        InventoryNumber = inventoryNumber;
        Name = name;
        Simplicity = simplicity;
    }
}