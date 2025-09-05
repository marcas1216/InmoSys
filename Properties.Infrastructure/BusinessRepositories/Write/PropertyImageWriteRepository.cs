
using Microsoft.EntityFrameworkCore;
using Properties.Aplication.Interface.Write;
using Properties.Entities.Write;
using Properties.Infrastructure.EF.Context;
using Properties.Infrastructure.EF.Entities;

namespace Properties.Infrastructure.BusinessRepositories.Write
{
    public class PropertyImageWriteRepository : IPropertyImageWriteRepository
    {
        private readonly PropertiesDbContext _context;

        public PropertyImageWriteRepository(PropertiesDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(AddPropertyImages request)
        {
            var lastId = await _context.PropertyImages
               .MaxAsync(p => (int?)p.Id) ?? 0;

            var entity = new PropertyImage
            {
                Id = lastId + 1,
                PropertyId = request.pPropertyId,
                File = request.pFile,
                Enabled = request.pEnabled,
                RegisterDate = DateTime.UtcNow, 
                State = 1
            };

            _context.PropertyImages.Add(entity);
            await _context.SaveChangesAsync();

            return entity.Id; 
        }
    }
}
