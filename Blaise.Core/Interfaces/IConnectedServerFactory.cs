using StatNeth.Blaise.API.ServerManager;

namespace Blaise.Core.Interfaces
{
    public interface IConnectedServerFactory
    {
        IConnectedServer GetConnection();
    }
}
