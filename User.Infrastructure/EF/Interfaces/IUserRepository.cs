
using User.Entities.Read;

namespace User.Infrastructure.EF.Interfaces
{
    public interface IUserRepository
    {
        Task<LoginResult> LoginAsync(UserLoginRequest request);
    }
}
