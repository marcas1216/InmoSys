
using Properties.Entities.Read;

namespace Properties.Aplication.Interface
{
    public interface IPropertyTypeRepository
    {
        Task<IEnumerable<LoadPropertyTypes>> GetAllAsync();
    }
}
