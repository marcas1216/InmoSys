using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using User.Entities.Write;
using User.Infrastructure.EF.Context;
using User.Infrastructure.EF.Entities;
using User.Infrastructure.EF.Interfaces;

namespace User.Infrastructure.EF.Repositories
{
    public class LogsRepository : ILogsRepository
    {
        private readonly IDbContextFactory<InmoSysCoreContext> _contextFactory;

        public LogsRepository(IDbContextFactory<InmoSysCoreContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task AddLogAsync(AddLogs itemsLog)
        {
            using var context = _contextFactory.CreateDbContext();

            try
            {
                var lastId = await context.Logs
                .Select(l => (int?)l.Id)
                .MaxAsync() ?? 0;

                var log = new Log
                {
                    Id = lastId + 1,
                    Module = itemsLog.LModule,
                    Method = itemsLog.LMethod,
                    Request = itemsLog.LRequest != null ? JsonSerializer.Serialize(itemsLog.LRequest) : string.Empty,
                    Response = itemsLog.LResponse != null ? JsonSerializer.Serialize(itemsLog.LResponse) : string.Empty,
                    State = 1
                };

                context.Logs.Add(log);
                await context.SaveChangesAsync();

            }
            catch (Exception exception)
            {
                throw new Exception($"Error: {exception.Message}");
            }   
        }
    }
}
