using ProyectAdmin.Core.DTOs;
using ProyectAdmin.Core.Models;

namespace ProyectAdmin.Core.Interfaces
{
    public interface IUserService
    {
        Task<User> AddAsync(UserCreateDto createDto);
    }
}
