using kpo_vishkat.Models;

namespace kpo_vishkat.Models;

public sealed class Bicycle : iTransport, iInventoryItem
{
    int iInventoryItem;
    string Name = "Bicycle";
    int Simplicity = 8;
}