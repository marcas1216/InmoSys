using Properties.Entities.Read;

namespace Properties.Aplication.Interface.Read
{
    public interface IPropertyStateRepository
    {
        Task<IEnumerable<LoadPropertyStates>> GetAllAsync();
    }
}
