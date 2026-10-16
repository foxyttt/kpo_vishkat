using kpo_vishkat.Models;

namespace kpo_vishkat.Models;

public class Park
{
    private readonly List<iInventoryItem> _items = new();

    public IReadOnlyCollection<iInventoryItem> Items => _items.AsReadOnly();

    public IEnumerable<iTransport> Transports => _items.OfType<iTransport>();

    public IEnumerable<iEnergyCustomer> EnergyConsumers => _items.OfType<iEnergyCustomer>();

    public void AddItem(iInventoryItem item)
    {
        ArgumentNullException.ThrowIfNull(item);

        if (_items.Any(x => x.InventoryNumber == item.InventoryNumber))
        {
            throw new InvalidOperationException(
                $"Объект с инвентарным номером {item.InventoryNumber} уже существует.");
        }

        _items.Add(item);
    }
}