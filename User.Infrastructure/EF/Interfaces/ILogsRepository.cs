
using User.Entities.Write;

namespace User.Infrastructure.EF.Interfaces
{
    public interface ILogsRepository
    {
        Task AddLogAsync(AddLogs itemsLog);
    }
}
