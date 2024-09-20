using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectAdmin.Core.DTOs.Models.User;
using ProyectAdmin.Core.Interfaces;
using ProyectAdmin.Core.Utils;

namespace ProyectAdmin.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService userService)
        {
            _authService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginRequest request)
        {
            var success = await _authService.Auth(request);
            return success ?
                Ok(ApiResponseHelper.CreateSuccessResponse("Logged"))
                : BadRequest(ApiResponseHelper.CreateErrorResponse<object>("Loggin failed", StatusCodes.Status400BadRequest));
        }
    }
}
