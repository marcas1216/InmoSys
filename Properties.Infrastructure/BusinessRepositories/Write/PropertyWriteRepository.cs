
using Microsoft.EntityFrameworkCore;
using Properties.Aplication.Interface.Write;
using Properties.Entities.Write;
using Properties.Infrastructure.EF.Context;
using Properties.Infrastructure.EF.Entities;

namespace Properties.Infrastructure.BusinessRepositories.Write
{
    public class PropertyWriteRepository : IPropertyWriteRepository
    {

        private readonly PropertiesDbContext _context;

        public PropertyWriteRepository(PropertiesDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddPropertyAsync(AddProperty property)
        {
            var lastId = await _context.Properties
              .MaxAsync(p => (int?)p.Id) ?? 0;

            var entity = new Property
            {
                Id = lastId+1,
                Name = property.Name,
                Address = property.Address,
                Price = property.Price,
                CodeInternal = property.CodeInternal,
                Year = property.Year,
                OwnerId = property.OwnerId,
                PropertyTypeId = property.PropertyTypeId,
                PropertyStateId = property.PropertyStateId,
                State = 1
            };

            _context.Properties.Add(entity);
            await _context.SaveChangesAsync();

            return entity.Id; 
        }
    }
}
