
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Properties.Aplication.Interface.Write;
using Properties.Entities.Write;
using Properties.Infrastructure.EF.Context;
using Properties.Infrastructure.EF.Entities;
using User.Entities.Write;
using User.Infrastructure.Constants;
using User.Infrastructure.EF.Interfaces;
using User.Infrastructure.EF.Repositories;

namespace Properties.Infrastructure.BusinessRepositories.Write
{
    public class PropertyWriteRepository : IPropertyWriteRepository
    {

        private readonly PropertiesDbContext _context;
        private readonly ILogsRepository _logsRepository;

        public PropertyWriteRepository(PropertiesDbContext context, ILogsRepository logsRepository)
        {
            (_context, _logsRepository) = (context, logsRepository);
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

            var log = new AddLogs
            {
                LModule = LogConstants.USER_MODULE,
                LMethod = "AddPropertyAsync",
                LRequest = property,
                LResponse = entity.Id
            };

            _ = _logsRepository.AddLogAsync(log);

            return entity.Id; 
        }

        public async Task<bool> UpdatePropertyAsync(int id, UpdateProperty request)
        {
            var property = await _context.Properties.FirstOrDefaultAsync(p => p.Id == id);
            if (property == null) return false;
                        
            property.Name = request.Name;
            property.Address = request.Address;
            property.Price = request.Price;
            property.CodeInternal = request.CodeInternal;
            property.Year = request.Year;
            property.OwnerId = request.OwnerId;
            property.PropertyStateId = request.PropertyStateId;

            await _context.SaveChangesAsync();

            var log = new AddLogs
            {
                LModule = LogConstants.USER_MODULE,
                LMethod = "AddPropertyAsync",
                LRequest = property,
                LResponse = true
            };

            _ = _logsRepository.AddLogAsync(log);

            return true;
        }

        public async Task ChangePriceAsync(int id, ChangePrices changePrice)
        {
            var entity = await _context.Properties.FirstOrDefaultAsync(p => p.Id == id);

            if (entity == null)
                throw new KeyNotFoundException($"Propiedad con Id {id} no encontrada");

            entity.Price = changePrice.Price;

            _context.Properties.Update(entity);
            await _context.SaveChangesAsync();

            var log = new AddLogs
            {
                LModule = LogConstants.USER_MODULE,
                LMethod = "AddPropertyAsync",
                LRequest = changePrice,
                LResponse = entity.Id
            };

            _ = _logsRepository.AddLogAsync(log);
        }
    }
}
