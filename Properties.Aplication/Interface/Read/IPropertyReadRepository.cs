
using Properties.Entities.Read;

namespace Properties.Aplication.Interface.Read
{
    public interface IPropertyReadRepository
    {
        Task<List<LoadProperty>> GetPropertiesAsync();
    }
}
