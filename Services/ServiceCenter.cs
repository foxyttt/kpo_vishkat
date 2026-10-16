using kpo_vishkat.Models;

namespace kpo_vishkat.Services;

public interface iServiceCenter
{
    bool Accept(iTransport transport);
}