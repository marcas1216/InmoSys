
using Microsoft.EntityFrameworkCore;
using Properties.Aplication.Interface;
using Properties.Entities.Read;
using Properties.Infrastructure.EF.Context;

namespace Properties.Infrastructure.BusinessRepositories.Read
{
    public class PropertyStateRepository : IPropertyStateRepository
    {
        private readonly PropertiesDbContext _context;

        public PropertyStateRepository(PropertiesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LoadPropertyStates>> GetAllAsync()
        {
            return await _context.PropertyStates
                .Select(ps => new LoadPropertyStates
                {
                    pstId = ps.Id,
                    pstName = ps.Name,
                    pstRegisterDate = ps.RegisterDate,
                    pstState = ps.State
                })
                .ToListAsync();
        }
    }
}
