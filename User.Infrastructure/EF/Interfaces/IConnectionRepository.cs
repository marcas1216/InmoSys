
namespace User.Infrastructure.EF.Interfaces
{
    public interface IConnectionRepository
    {
        Task<string?> GetActiveConnectionAsync(string serviceName);
    }
}
