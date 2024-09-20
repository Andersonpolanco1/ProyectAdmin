
using ProyectAdmin.Core.DTOs.Models.User;
using ProyectAdmin.Core.Interfaces;

namespace ProyectAdmin.Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;

        public AuthService(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<bool> Auth(UserLoginRequest request)
        {
            var user = await _userService.GetByEmail(request.Email);

            if (user is null)
                return false;

            return _userService.VerifyPassword(user, request.Password);
        }
    }
}
