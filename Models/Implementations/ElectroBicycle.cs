using kpo_vishkat.Models;

namespace kpo_vishkat.Models;

public sealed class ElectroBicycle : iTransport, iInventoryItem
{
    int iInventoryItem;
    string Name = "ElectroBicycle";
    int Simplicity = 6;
    
}