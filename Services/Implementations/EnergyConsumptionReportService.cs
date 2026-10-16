using kpo_vishkat.Models;
using kpo_vishkat.Services;

namespace kpo_vishkat.Services.Implementations;

public class EnergyConsumptionReportService : iReportService
{
    private readonly Park _park;

    public string Name => "Суточное энергопотребление";

    public EnergyConsumptionReportService(Park park)
    {
        _park = park;
    }

    public string generate()
    {
        double total = _park.EnergyConsumers.Sum(consumer => consumer.EnergyConsumption);

        return $"Суммарное суточное энергопотребление: {total:F2} кВт·ч";
    }
}