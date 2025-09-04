
using Owner.Entities.Read;

namespace Owner.Infrastructure.EF.Interfaces
{
    public interface IConnectionRepository
    {
        Task<string?> GetActiveConnectionAsync(string serviceName);
    }
}
