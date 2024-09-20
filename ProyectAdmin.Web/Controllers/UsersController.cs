using Microsoft.AspNetCore.Mvc;
using ProyectAdmin.Core.DTOs;
using ProyectAdmin.Core.DTOs.ApiResponse;
using ProyectAdmin.Core.DTOs.Models.User;
using ProyectAdmin.Core.DTOs.QueryFilters;
using ProyectAdmin.Core.Exceptions.Infrastructure;
using ProyectAdmin.Core.Interfaces;
using ProyectAdmin.Core.Models;
using ProyectAdmin.Core.Utils;
using System.Text.Json;

namespace ProyectAdmin.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponseOk<PaginatedList<User>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponseError<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUsers([FromQuery] UserQueryFilter filtro)
        {
            try
            {
                var users = await _userService.GetUsers(filtro);
                return Ok(ApiResponseHelper.CreateSuccessResponse(users, StatusCodes.Status200OK));
            }
            catch (FilterException ex)
            {
                return BadRequest(ApiResponseHelper.CreateErrorResponse<UserQueryFilter>(ex.Message, StatusCodes.Status400BadRequest));
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
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


        [Route("load")]
        [HttpPost]
        public async Task<IActionResult> LoadUsers([FromBody] bool execute)
        {
            try
            {
                string jsonFilePath = "C:\\Users\\Andy\\Downloads\\MOCK_DATA.json";
                var jsonData = await System.IO.File.ReadAllTextAsync(jsonFilePath);

                var users = JsonSerializer.Deserialize<List<UserCreateDto>>(jsonData);

                if (users == null || users.Count == 0)
                    return Ok("Sin registros para procesar");

                foreach (var user in users)
                    await _userService.AddAsync(user, saveChanges:false);

                var data = new
                {
                    UsuariosCreados = await  _userService.SaveChangesAsync()
                };

                return Ok(ApiResponseHelper.CreateSuccessResponse(data, StatusCodes.Status201Created));
            }
            catch (EntityExistsException ex)
            {
                return BadRequest(ApiResponseHelper.CreateErrorResponse<UserCreateDto>(ex.Message, StatusCodes.Status400BadRequest));
            }
        }
    }
}
