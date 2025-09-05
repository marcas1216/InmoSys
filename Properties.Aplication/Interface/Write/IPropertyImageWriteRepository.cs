
using Properties.Entities.Write;

namespace Properties.Aplication.Interface.Write
{
    public interface IPropertyImageWriteRepository
    {
        Task<int> AddAsync(AddPropertyImages request);
    }
}
