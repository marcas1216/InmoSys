
using Microsoft.EntityFrameworkCore;
using Properties.Aplication.Interface;
using Properties.Entities.Read;
using Properties.Infrastructure.EF.Context;

namespace Properties.Infrastructure.BusinessRepositories.Read
{
    public class PropertyImageRepository : IPropertyImageRepository
    {
        private readonly PropertiesDbContext _context;

        public PropertyImageRepository(PropertiesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LoadPropertyImages>> GetAllByPropertyAsync(int propertyId)
        {
            return await _context.PropertyImages
                .AsNoTracking()
                .Where(img => img.PropertyId == propertyId && img.Enabled)
                .Select(img => new LoadPropertyImages
                {
                    pPropertyId = img.PropertyId,
                    pFile = img.File,
                    pEnabled = img.Enabled
                })
                .ToListAsync();
        }
    }
}
