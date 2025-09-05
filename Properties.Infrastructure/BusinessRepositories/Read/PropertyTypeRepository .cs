
using Microsoft.EntityFrameworkCore;
using Properties.Aplication.Interface;
using Properties.Entities.Read;
using Properties.Infrastructure.EF.Context;

namespace Properties.Infrastructure.BusinessRepositories.Read
{
    public class PropertyTypeRepository : IPropertyTypeRepository
    {
        private readonly PropertiesDbContext _context;

        public PropertyTypeRepository(PropertiesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LoadPropertyTypes>> GetAllAsync()
        {
            return await _context.PropertyTypes
                .AsNoTracking()
                .Select(pt => new LoadPropertyTypes
                {
                    ptyId = pt.Id,
                    ptyName = pt.Name,
                    ptyDescription = pt.Description ?? string.Empty,
                    ptyRegisterDate = pt.RegisterDate,
                    ptyState = pt.State
                })
                .ToListAsync();
        }
    }
}
