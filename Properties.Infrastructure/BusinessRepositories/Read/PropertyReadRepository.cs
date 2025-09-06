
using Microsoft.EntityFrameworkCore;
using Properties.Aplication.Interface.Read;
using Properties.Entities.Read;
using Properties.Infrastructure.EF.Context;

namespace Properties.Infrastructure.BusinessRepositories.Read
{
    public class PropertyReadRepository : IPropertyReadRepository
    {
        private readonly PropertiesDbContext _context;

        public PropertyReadRepository(PropertiesDbContext context)
        {
            _context = context;
        }

        public async Task<List<LoadProperty>> GetPropertiesAsync()
        {
            return await _context.Properties
                .AsNoTracking()
                .Select(p => new LoadProperty
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Address, 
                    RegisterDate = p.RegisterDate,
                    State = p.State
                })
                .ToListAsync();
        }
    }
}
