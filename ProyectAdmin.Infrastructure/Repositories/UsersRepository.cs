using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProyectAdmin.Core.Models;
using ProyectAdmin.Core.Interfaces;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace ProyectAdmin.Infrastructure.Repositories
{
    public class UsersRepository : IRepository<User>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<UsersRepository> _logger;


        public UsersRepository(ApplicationDbContext context, ILogger<UsersRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<User> AddAsync(User entity, bool SaveChanges = true)
        {
            await _context.AddAsync(entity);

            if (SaveChanges)
                await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> DeleteAsync(int id, bool SaveChanges = true)
        {
            if (id == default)
                return await System.Threading.Tasks.Task.FromResult(false);

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user is null)
                return await System.Threading.Tasks.Task.FromResult(false);

            _context.Users.Remove(user);

            if (SaveChanges)
            {
                var affectedRows = await _context.SaveChangesAsync();
                return affectedRows > 0;
            }
            return false;
        }

        public async Task<IEnumerable<User>> FindAsync(Expression<Func<User, bool>> predicate, bool asNoTracking = false)
        {
            IQueryable<User> query = _context.Users;

            if (asNoTracking)
                query = query.AsNoTracking();

            return await query.Where(predicate).ToListAsync();
        }

        public async Task<User?> FirstAsync(Expression<Func<User, bool>> predicate, bool asNoTracking = false)
        {
            IQueryable<User> query = _context.Users;

            if (asNoTracking)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync(predicate);
        }

        public async Task<bool> ExistAsync(Expression<Func<User, bool>> predicate, bool asNoTracking = false)
        {
            IQueryable<User> query = _context.Users;

            if (asNoTracking)
                query = query.AsNoTracking();

            var user = await query.AsNoTracking().FirstOrDefaultAsync(predicate);

            return user != null;
        }

        public Task<IEnumerable<User>> GetAllAsync(bool asNoTracking = false)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByIdAsync(int id, bool asNoTracking = false)
        {
            IQueryable<User> query = _context.Users;

            if (asNoTracking)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync(u => u.Id == id);
        }

        public System.Threading.Tasks.Task UpdateAsync(User entity, bool SaveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
