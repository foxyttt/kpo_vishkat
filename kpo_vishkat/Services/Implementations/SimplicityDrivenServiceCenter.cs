using kpo_vishkat.Models;
using kpo_vishkat.Services;

namespace kpo_vishkat.Services.Implementations;

public class SimplicityDrivenServiceCenter : iServiceCenter
{
    public bool Accept(iTransport transport)
    {
        ArgumentNullException.ThrowIfNull(transport);

        if (transport.Simplicity < 3)
        {
            return false;
        }

        return true;
    }
}
