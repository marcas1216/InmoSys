using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Entities.Read;
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

        public async Task<List<Connection>> GetActiveConnectionsAsync()
        {
            var connections = await _context.Connections
                .Where(c => c.State == 1)
                .ToListAsync();

            return connections.Select(c => new Connection
            {
                ServiceName = c.ServiceName,
                ConnectionString = SecurityHelper.Decrypt(Convert.FromBase64String(c.ConnectionString!), c.ServiceName)              
            }).ToList();
        }
    }
}
