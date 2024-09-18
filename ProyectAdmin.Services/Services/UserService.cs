
using Microsoft.AspNetCore.Identity;
using ProyectAdmin.Core.DTOs;
using ProyectAdmin.Core.Exceptions.Infrastructure;
using ProyectAdmin.Core.Interfaces;
using ProyectAdmin.Core.Models;

namespace ProyectAdmin.Services.Services
{
    public class UserService(IRepository<User> userRepository) : IUserService
    {
        private readonly IRepository<User> _userRepository = userRepository;
        private readonly PasswordHasher<UserCreateDto> _passwordHasher = new();

        public async Task<User> AddAsync(UserCreateDto createDto)
        {
            var userExist =
                await _userRepository.ExistAsync(u => u.Name.ToUpper() == createDto.Name.ToUpper()
                || u.Email.ToUpper() == createDto.Email.ToUpper(), true);


            if (userExist)
                throw new EntityExistsException();

            var newUser = new User
            {
                Name = createDto.Name,
                Email = createDto.Email.ToLower(),
                Password = _passwordHasher.HashPassword(createDto, createDto.Password)
            };

            return await _userRepository.AddAsync(newUser);
        }
    }
}
