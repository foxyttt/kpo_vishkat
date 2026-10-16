namespace kpo_vishkat.Services;

public interface IServiceCenter
{
    bool Accept(iTransport transport);
}

public class ServiceCenter : IServiceCenter
{
    public bool Accept(iTransport transport)
    {
        return true;
    }
}