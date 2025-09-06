
namespace User.Infrastructure.EF.Interfaces
{
    public interface IKeyVaultRepository
    {
        Task<byte[]> GetJwtSecretAsync(string module);
    }
}
