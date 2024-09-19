using ProyectAdmin.Core.Utils;
using ProyectAdmin.Core.DTOs;
using ProyectAdmin.Core.DTOs.Filters;
using ProyectAdmin.Core.Models;

namespace ProyectAdmin.Core.Interfaces
{
    public interface IUserService
    {
        Task<User> AddAsync(UserCreateDto createDto, bool saveChanges = true);
        Task<PaginatedList<User>> GetUsers(UserFilter filter, bool asNoTracking = true);
        Task<int> SaveChangesAsync();
    }
}
