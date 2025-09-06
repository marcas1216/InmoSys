
using Properties.Entities.Write;

namespace Properties.Aplication.Interface.Write
{
    public interface IPropertyWriteRepository
    {
        Task<int> AddPropertyAsync(AddProperty property);
        Task<bool> UpdatePropertyAsync(int id, UpdateProperty property);
        Task ChangePriceAsync(int id, ChangePrices changePrice);
    }
}
