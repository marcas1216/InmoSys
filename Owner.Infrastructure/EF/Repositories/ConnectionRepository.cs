
using Microsoft.EntityFrameworkCore;
using Owner.Entities.Read;
using Owner.Infrastructure.EF.Helpers;
using Owner.Infrastructure.EF.Interfaces;
using User.Infrastructure.EF.Context;

namespace Owner.Infrastructure.EF.Repositories
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
                var decryptedConnString = OwnerSecurityHelper.Decrypt(
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
