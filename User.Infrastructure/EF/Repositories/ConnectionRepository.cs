
using Microsoft.EntityFrameworkCore;
using User.Infrastructure.EF.Context;
using User.Infrastructure.EF.Helpers;
using User.Infrastructure.EF.Interfaces;

namespace User.Infrastructure.EF.Repositories
{
    public class ConnectionRepository : IConnectionRepository
    {
        private readonly InmoSysCoreContext _context;

        public ConnectionRepository(InmoSysCoreContext context)
        {
            _context = context;
        }

        public async Task<string?> GetActiveConnectionAsync(string serviceName)
        {
            var connection = await _context.Connections
                .AsNoTracking()
                .Where(x => x.ServiceName == serviceName && x.State == 1)
                .FirstOrDefaultAsync();

            if (connection == null)
                return null;

            try
            {
                var decryptedConnString = SecurityHelper.Decrypt(
                    connection.ConnectionString!,
                    connection.ServiceName
                );

                return decryptedConnString;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error desencriptando la conexión {serviceName}: {ex.Message}", ex);
            }
        }
    }
}
