using kpo_vishkat.Models;
using kpo_vishkat.Services;

namespace kpo_vishkat.Services.Implementations;

public class InventoryReportService : iReportService
{
    private readonly Park _park;

    public string Name => "Полная инвентаризация";

    public InventoryReportService(Park park)
    {
        _park = park;
    }

    public string generate()
    {
        if (_park.Items.Count == 0)
        {
            return "Парк пока пуст.";
        }

        return "Инвентаризация:\n" + string.Join("\n", _park.Items.Select(item => $"{item.Name} | № {item.InventoryNumber}"));
    }
}