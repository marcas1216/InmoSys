using Properties.Entities.Read;

namespace Properties.Aplication.Interface.Read
{
    public interface IPropertyImageRepository
    {
        Task<IEnumerable<LoadPropertyImages>> GetAllByPropertyAsync(int propertyId);
    }
}
