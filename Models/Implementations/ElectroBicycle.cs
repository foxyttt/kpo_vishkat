using kpo_vishkat.Models;

namespace kpo_vishkat.Models;

public sealed class ElectroBicycle : iTransport, iInventoryItem, iEnergyCustomer
{
    int iInventoryItem;
    string Name = "ElectroBicycle";

    double EnergyConsumption = 10;
    int Simplicity = 4;
    
}