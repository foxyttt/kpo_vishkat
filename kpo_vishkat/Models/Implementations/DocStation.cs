using kpo_vishkat.Models;

namespace kpo_vishkat.Models;

public sealed class DocStation : iEnergyCustomer
{
    public string InventoryNumber { get; }
    public string Name {  get; }
    public double EnergyConsumption {  get; }

    public DocStation(string inventoryNumber, string name, double energyConsumption)
    {
        InventoryNumber = inventoryNumber;
        Name = name;
        EnergyConsumption = energyConsumption;
    }
}