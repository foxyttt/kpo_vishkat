namespace kpo_vishkat.Models;

public interface iEnergyCustomer : iInventoryItem
{
    double EnergyConsumption {get; }
}