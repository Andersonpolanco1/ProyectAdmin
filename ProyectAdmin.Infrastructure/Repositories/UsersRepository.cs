using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProyectAdmin.Core.Models;
using ProyectAdmin.Core.Interfaces;
using System.Linq.Expressions;
using ProyectAdmin.Core.DTOs.Filters;
using ProyectAdmin.Core.Utils;

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

        public async Task<bool> ExistAsync(Expression<Func<User, bool>> predicate, bool asNoTracking = false)
        {
            IQueryable<User> query = _context.Users;

            if (asNoTracking)
                query = query.AsNoTracking();

            var user = await query.AsNoTracking().FirstOrDefaultAsync(predicate);

            return user != null;
        }

        public async Task<User?> GetByIdAsync(int id, bool asNoTracking = false)
        {
            IQueryable<User> query = _context.Users;

            if (asNoTracking)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<PaginatedList<User>> FindAsync(BaseFilter filter, bool paginated = false, bool asNoTracking = true)
        {
            IQueryable<User> usersQuery = _context.Users;

            if (filter is UserFilter userFilter)
            {
                if (asNoTracking)
                    usersQuery = usersQuery.AsNoTracking().AsQueryable();

                if (userFilter.Id.HasValue)
                    usersQuery = usersQuery.Where(u => u.Id == userFilter.Id);

                if (!string.IsNullOrWhiteSpace(userFilter.Name))
                    usersQuery = usersQuery.Where(u => u.Name.StartsWith(userFilter.Name));

                if (!string.IsNullOrWhiteSpace(userFilter.Email))
                    usersQuery = usersQuery.Where(u => u.Email.ToLower() == userFilter.Email.ToLower());

                if (!string.IsNullOrEmpty(userFilter.OrderBy))
                {
                    if (!AppUtils.HasProperty<User>(AppUtils.CapitalizeFirstLetter(userFilter.OrderBy)))
                        throw new ArgumentException($"La propiedad {userFilter.OrderBy} no existe, no se puede filtrar los registros.");

                    usersQuery = filter.SortOrder == SortOrder.Asc
                        ? usersQuery.OrderBy(e => EF.Property<object>(e, AppUtils.CapitalizeFirstLetter(userFilter.OrderBy)))
                        : usersQuery.OrderByDescending(e => EF.Property<object>(e, AppUtils.CapitalizeFirstLetter(userFilter.OrderBy)));
                }
            }

            var data = await PaginatedList<User>.CreateAsync(usersQuery, filter.PageIndex, filter.PageSize);

            return data;
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
