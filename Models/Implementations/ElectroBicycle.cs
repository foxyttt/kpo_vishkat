using kpo_vishkat.Models;

namespace kpo_vishkat.Models;

public sealed class ElectroBicycle : iTransport, iEnergyCustomer
{
    public string InventoryNumber { get; }
    public string Name {  get; }
    public double EnergyConsumption {  get; }
    public int Simplicity {  get; }

    public ElectroBicycle(string inventoryNumber, string name, double energyConsumption, int simplicity)
    {
        InventoryNumber = inventoryNumber;
        Name = name;
        EnergyConsumption = energyConsumption;
        Simplicity = simplicity;
    }
}