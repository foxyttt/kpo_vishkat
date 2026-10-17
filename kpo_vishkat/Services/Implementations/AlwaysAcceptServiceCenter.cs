using kpo_vishkat.Models;
using kpo_vishkat.Services;

namespace kpo_vishkat.Services.Implementations;

public class AlwaysAcceptServiceCenter : iServiceCenter
{
    public bool Accept(iTransport transport)
    {
        ArgumentNullException.ThrowIfNull(transport);

        return true;
    }
}