
using User.Entities.Read;

namespace User.Infrastructure.EF.Interfaces
{
    public interface IConnectionRepository
    {
        Task<List<Connection>> GetActiveConnectionsAsync();
    }
}
