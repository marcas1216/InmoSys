
using Properties.Entities.Read;

namespace Properties.Aplication.Interface
{
    public interface IPropertyImageRepository
    {
        Task<IEnumerable<LoadPropertyImages>> GetAllByPropertyAsync(int propertyId);
    }
}
