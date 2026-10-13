using kpo_vishkat.Models;

namespace kpo_vishkat.Models;

public class Park
{
    private readonly List<iTransport> _transports = new();
    private readonly List<iInventoryItem> _items = new();
}