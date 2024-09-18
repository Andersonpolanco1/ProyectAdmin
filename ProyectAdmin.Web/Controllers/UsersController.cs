using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProyectAdmin.Core.DTOs;
using ProyectAdmin.Core.DTOs.Filters;
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

        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] UserFilter filtro)
        {
            try
            {
                var users = await _userService.GetUsers(filtro);
                return Ok(ApiResponseHelper.CreateSuccessResponse(users, StatusCodes.Status200OK));
            }
            catch (FilterException ex)
            {
                return BadRequest(ApiResponseHelper.CreateErrorResponse<UserFilter>(ex.Message, StatusCodes.Status500InternalServerError));
            }
        }

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
