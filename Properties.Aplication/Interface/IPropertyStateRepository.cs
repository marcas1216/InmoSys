
using Properties.Entities.Read;

namespace Properties.Aplication.Interface
{
    public interface IPropertyStateRepository
    {
        Task<IEnumerable<LoadPropertyStates>> GetAllAsync();
    }
}
