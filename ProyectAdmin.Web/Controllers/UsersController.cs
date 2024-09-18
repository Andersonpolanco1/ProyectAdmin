using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProyectAdmin.Core.DTOs;
using ProyectAdmin.Core.Exceptions.Infrastructure;
using ProyectAdmin.Core.Interfaces;
using ProyectAdmin.Core.Utils;

namespace ProyectAdmin.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpPost]
        public async Task<IActionResult> AddUser(UserCreateDto userCreate)
        {
            try
            {
                var newUser = await _userService.AddAsync(userCreate);
                return Ok(ApiResponseHelper.CreateSuccessResponse(newUser, StatusCodes.Status201Created));
            }
            catch (EntityExistsException ex)
            {
                return BadRequest(ApiResponseHelper.CreateErrorResponse<UserCreateDto>(ex.Message, StatusCodes.Status400BadRequest));
            }
        }
    }
}
