using ProyectAdmin.Core.Models;
using System.Linq.Expressions;

namespace ProyectAdmin.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id, bool asNoTracking = false);
        Task<IEnumerable<T>> GetAllAsync(bool asNoTracking = false);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, bool asNoTracking = false);
        Task<bool> ExistAsync(Expression<Func<T, bool>> predicate, bool asNoTracking = false);
        Task<T?> FirstAsync(Expression<Func<T, bool>> predicate, bool asNoTracking = false);
        Task<T> AddAsync(T entity, bool SaveChanges = true);
        System.Threading.Tasks.Task UpdateAsync(T entity, bool SaveChanges = true);

        /// <summary>
        /// Intenta eliminar una entidad buscando por su ID.
        /// </summary>
        /// <param name="id">El identificador de la entidad que se intentará eliminar.</param>
        /// <returns>
        /// <c>true</c> si el registro fue encontrado y eliminado exitosamente; de lo contrario, <c>false</c>.
        /// </returns>
        Task<bool> DeleteAsync(int id, bool SaveChanges = true);

    }
}
