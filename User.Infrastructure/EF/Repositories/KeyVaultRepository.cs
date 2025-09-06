
using Microsoft.EntityFrameworkCore;
using System.Text;
using User.Infrastructure.EF.Context;
using User.Infrastructure.EF.Interfaces;

namespace User.Infrastructure.EF.Repositories
{
    public class KeyVaultRepository : IKeyVaultRepository
    {
        private readonly InmoSysCoreContext _context;

        public KeyVaultRepository(InmoSysCoreContext context) 
        {
            _context = context;
        }

        public async Task<byte[]> GetJwtSecretAsync(string module)
        {
            var keyVault = await _context.KeyVaults
                .AsNoTracking()
                .FirstOrDefaultAsync(k => k.Name == "SecretJwt" && k.Module == module);

            if (keyVault == null)
                throw new Exception($"No se encontró el secreto para el módulo '{module}' en [auth].[KeyVaults].");

            return Encoding.UTF8.GetBytes(keyVault.Value);
        }
    }
}
