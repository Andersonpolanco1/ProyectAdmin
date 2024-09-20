using ProyectAdmin.Core.Utils;
using Microsoft.AspNetCore.Identity;
using ProyectAdmin.Core.DTOs;
using ProyectAdmin.Core.DTOs.QueryFilters;
using ProyectAdmin.Core.Exceptions.Infrastructure;
using ProyectAdmin.Core.Interfaces;
using ProyectAdmin.Core.Models;
using ProyectAdmin.Core.DTOs.Models.User;

namespace ProyectAdmin.Services.Services
{
    public class UserService(IRepository<User> userRepository) : IUserService
    {
        private readonly IRepository<User> _userRepository = userRepository;
        private readonly PasswordHasher<User> _passwordHasher = new();

        public async Task<User> AddAsync(UserCreateDto createDto, bool saveChanges = true)
        {
            var userExist = await _userRepository.ExistAsync(u =>
                u.Name.ToLower() == createDto.Name.ToLower() ||
                u.Email.ToLower() == createDto.Email.ToLower(),
                asNoTracking: true
            );

            if (userExist)
                throw new EntityExistsException();

            var newUser = new User
            {
                Name = createDto.Name,
                Email = createDto.Email.ToLower(),
            };
            newUser.Password = _passwordHasher.HashPassword(newUser, createDto.Password);

            return await _userRepository.AddAsync(newUser, saveChanges);
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _userRepository.GetByEmail(email);
        }

        public async Task<PaginatedList<User>> GetUsers(UserQueryFilter filter, bool asNoTracking = true)
        {
            try
            {
                return await _userRepository.FindAsync(filter, asNoTracking);
            }
            catch (ArgumentException ex)
            {
                throw new FilterException(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _userRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new SaveChangesException(ex.Message);
            }
        }

        public bool VerifyPassword(User user, string providedPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, providedPassword);

            return result == PasswordVerificationResult.Success;
        }
    }
}
