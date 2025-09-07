
using Microsoft.EntityFrameworkCore;
using Properties.Aplication.Interface.Write;
using Properties.Entities.Write;
using Properties.Infrastructure.EF.Context;
using Properties.Infrastructure.EF.Entities;
using User.Entities.Write;
using User.Infrastructure.Constants;
using User.Infrastructure.EF.Interfaces;

namespace Properties.Infrastructure.BusinessRepositories.Write
{
    public class PropertyImageWriteRepository : IPropertyImageWriteRepository
    {
        private readonly PropertiesDbContext _context;
        private readonly ILogsRepository _logsRepository;   

        public PropertyImageWriteRepository(PropertiesDbContext context, ILogsRepository logsRepository)
        {
            (_context, _logsRepository) = (context, logsRepository);
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

            var log = new AddLogs
            {
                LModule = LogConstants.PROPERTIES_MODULE,
                LMethod = "AddAsync",
                LRequest = request,
                LResponse = entity.Id
            };

            _ = _logsRepository.AddLogAsync(log);

            return entity.Id; 
        }
    }
}
