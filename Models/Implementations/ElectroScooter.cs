using kpo_vishkat.Models;
using System.Diagnostics.Contracts;

namespace kpo_vishkat.Models;

public sealed class ElectroScooter : iTransport, iEnergyCustomer
{
    public string InventoryNumber { get; }
    public string Name {  get; }
    public double EnergyConsumption {  get; }
    public int Simplicity { get; }

    public ElectroScooter(string inventoryNumber, string name, double energyConsumption, int simplicity)
    {
        InventoryNumber = inventoryNumber;
        Name = name;
        EnergyConsumption = energyConsumption;
        Simplicity = simplicity;
    }
}