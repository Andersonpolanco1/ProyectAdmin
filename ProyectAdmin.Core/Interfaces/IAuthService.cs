using ProyectAdmin.Core.DTOs.Models.User;

namespace ProyectAdmin.Core.Interfaces
{
    public interface IAuthService
    {
        Task<bool> Auth(UserLoginRequest request);
    }
}
