using kpo_vishkat.Models;
using kpo_vishkat.Services;

namespace kpo_vishkat.Services.Implementations;

public class BeginnerFriendlyReportService : iReportService
{
    private readonly Park _park;

    public string Name => "Транспорт для новичков";

    public BeginnerFriendlyReportService(Park park)
    {
        _park = park;
    }

    public string generate()
    {
        var transports = _park.Transports
            .Where(transport => transport.Simplicity >= 6)
            .ToList();

        if (transports.Count == 0)
            return "Нет транспорта, подходящего для новичков.";

        return "Транспорт для новичков:\n" +
               string.Join("\n", transports.Select(
                   transport =>
                       $"{transport.Name} | № {transport.InventoryNumber} " +
                       $"| Простота: {transport.Simplicity}/10"));
    }
}