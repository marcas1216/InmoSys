
using Properties.Entities.Read;

namespace Properties.Aplication.Interface.Read
{
    public interface IPropertyReadRepository
    {
        Task<List<LoadProperty>> GetPropertiesAsync();
        Task<List<LoadProperty>> GetPropertiesByOwnerAsync(int ownerId);
        Task<List<LoadProperty>> GetPropertiesByStateAsync(int propertyStateId);
        Task<List<LoadProperty>> GetPropertiesByTypeAsync(int propertyTypeId);
    }
}
