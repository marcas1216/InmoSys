
using Microsoft.EntityFrameworkCore;
using Properties.Aplication.Interface.Read;
using Properties.Entities.Read;
using Properties.Infrastructure.EF.Context;
using System.Diagnostics;

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
                    Price = p.Price,
                    RegisterDate = p.RegisterDate,
                    State = p.State
                })
                .ToListAsync();
        }

        public async Task<List<LoadProperty>> GetPropertiesByOwnerAsync(int ownerId)
        {
            return await _context.Properties
                .Where(p => p.OwnerId == ownerId)
                .AsNoTracking()
                .Select(p => new LoadProperty
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Address,
                    Price = p.Price,
                    RegisterDate = p.RegisterDate,
                    State = p.State
                })
                .ToListAsync();
        }

        public async Task<List<LoadProperty>> GetPropertiesByStateAsync(int propertyStateId)
        {
            return await _context.Properties
                .Where(p => p.PropertyStateId == propertyStateId)
                .AsNoTracking()
                .Select(p => new LoadProperty
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Address,
                    Price = p.Price,
                    RegisterDate = p.RegisterDate,
                    State = p.State
                })
                .ToListAsync();
        }

        public async Task<List<LoadProperty>> GetPropertiesByTypeAsync(int propertyTypeId)
        {
            return await _context.Properties
                .Where(p => p.PropertyTypeId == propertyTypeId)
                .AsNoTracking()
                .Select(p => new LoadProperty
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Address,
                    Price = p.Price,
                    RegisterDate = p.RegisterDate,
                    State = p.State
                })
                .ToListAsync();
        }
    }
}
