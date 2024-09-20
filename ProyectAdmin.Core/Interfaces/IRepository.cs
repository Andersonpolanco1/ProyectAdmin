using ProyectAdmin.Core.Utils;
using ProyectAdmin.Core.DTOs.QueryFilters;
using ProyectAdmin.Core.Models;
using System.Linq.Expressions;

namespace ProyectAdmin.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id, bool asNoTracking = false);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, bool asNoTracking = false);
        Task<bool> ExistAsync(Expression<Func<T, bool>> predicate, bool asNoTracking = false);


        /// <summary>
        /// Intenta agregar una nueva entidad.
        /// </summary>
        /// <typeparam name="T">El tipo de la entidad que se está agregando.</typeparam>
        /// <param name="entity">Entidad para ser agregada.</param>
        /// <param name="SaveChanges">Parámetro opcional para guardar cambios inmediatamente.</param>
        /// <returns>
        /// La entidad agregada de tipo <typeparamref name="T"/> con su ID asignado.
        /// </returns>
        Task<T> AddAsync(T entity, bool SaveChanges = true);

        /// <summary>
        /// Intenta eliminar una entidad buscando por su ID.
        /// </summary>
        /// <param name="id">El identificador de la entidad que se intentará eliminar.</param>
        /// <returns>
        /// <c>true</c> si el registro fue encontrado y eliminado exitosamente; de lo contrario, <c>false</c>.
        /// </returns>
        Task<bool> DeleteAsync(int id, bool SaveChanges = true);

        Task<PaginatedList<T>> FindAsync(BaseQueryFilter filters, bool paginated = false, bool asNoTracking = true);

        Task<int> SaveChangesAsync();
        Task<User?> GetByEmail(string email);
    }
}
