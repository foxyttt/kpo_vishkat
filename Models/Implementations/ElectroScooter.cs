using kpo_vishkat.Models;

namespace kpo_vishkat.Models;

public sealed class ElectroBicycle : iTransport, iInventoryItem, iEnergyCustomer
{
    int iInventoryItem;
    string Name = "ElectroScooter";

    double EnergyConsumption = 5;
    int Simplicity = 6;
    
}