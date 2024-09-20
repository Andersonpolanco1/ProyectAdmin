using ProyectAdmin.Core.Utils;
using ProyectAdmin.Core.DTOs.QueryFilters;
using ProyectAdmin.Core.Models;
using ProyectAdmin.Core.DTOs.Models.User;

namespace ProyectAdmin.Core.Interfaces
{
    public interface IUserService
    {
        Task<User> AddAsync(UserCreateDto createDto, bool saveChanges = true);
        Task<PaginatedList<User>> GetUsers(UserQueryFilter filter, bool asNoTracking = true);
        Task<int> SaveChangesAsync();
        Task<User?> GetByEmail(string email);
        bool VerifyPassword(User user, string providedPassword);
    }
}
