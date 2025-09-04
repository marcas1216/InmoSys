

using Owner.Entities.Read;

namespace Owner.Aplication.Interface
{
    public interface IOwnerService
    {
        Task<IEnumerable<AllOwners>> GetAllAsync();
    }
}
