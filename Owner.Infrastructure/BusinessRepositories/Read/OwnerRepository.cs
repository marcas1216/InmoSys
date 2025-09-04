using Microsoft.EntityFrameworkCore;
using Owner.Aplication.Interface;
using Owner.Entities.Read;
using Owner.Infrastructure.EF.Context;

namespace Owner.Infrastructure.BusinessRepositories.Read
{
    public class OwnerRepository : IOwnerService
    {
        private readonly OwnerDbContext _context;

        public OwnerRepository(OwnerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AllOwners>> GetAllAsync()
        {
            return await _context.Owners
                .AsNoTracking()
                .Select(o => new AllOwners
                {
                    OId = o.OId,
                    OFirstName = o.OFirstName,
                    OLastName = o.OLastName,
                    ODocumentType = o.ODocumentType,
                    ODocument = o.ODocument,
                    OEmail = o.OEmail,
                    OAddress = o.OAddress,
                    OCity = o.OCity,
                    OState = o.OState,
                    OCountry = o.OCountry,
                    OPhoto = o.OPhoto,
                    OBirthDate = o.OBirthDate,
                    OPhone = o.OPhone,
                    ORegisterDate = o.ORegisterDate,
                    OStateRegister = o.OStateRegister
                })
                .ToListAsync();
        }
    }
}
