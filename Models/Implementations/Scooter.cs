using kpo_vishkat.Models;

namespace kpo_vishkat.Models;

public sealed class Scooter : iTransport, iInventoryItem
{
    int iInventoryItem;
    string Name = "Scooter";
    int Simplicity = 10;
}