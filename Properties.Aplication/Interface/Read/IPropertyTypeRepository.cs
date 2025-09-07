using Properties.Entities.Read;

namespace Properties.Aplication.Interface.Read
{
    public interface IPropertyTypeRepository
    {
        Task<IEnumerable<LoadPropertyTypes>> GetAllAsync();
    }
}
