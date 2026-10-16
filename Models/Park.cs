using System.Linq;

namespace kpo_vishkat.Models;

public class Park
{
    private readonly List<IInventoryItem> _items = new();

    public IReadOnlyCollection<IInventoryItem> Items =>
        _items.AsReadOnly();

    public IEnumerable<ITransport> Transports =>
        _items.OfType<ITransport>();

    public void AddItem(IInventoryItem item)
    {
        ArgumentNullException.ThrowIfNull(item);

        if (_items.Any(x => x.InventoryNumber == item.InventoryNumber))
        {
            throw new InvalidOperationException(
                $"Объект с инвентарным номером " +
                $"{item.InventoryNumber} уже существует.");
        }

        _items.Add(item);
    }
}