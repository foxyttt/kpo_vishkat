using kpo_vishkat.Models;
using kpo_vishkat.Services;

namespace kpo_vishkat.Services.Implementations;

public class TransportCountReportService : iReportService
{
    private readonly Park _park;

    public string Name => "Количество транспорта";

    public TransportCountReportService(Park park)
    {
        _park = park;
    }

    public string generate()
    {
        return $"Количество транспортных средств: {_park.Transports.Count()}";
    }
}