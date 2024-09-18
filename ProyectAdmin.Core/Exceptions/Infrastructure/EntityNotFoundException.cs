
namespace ProyectAdmin.Core.Exceptions.Infrastructure
{
    public class EntityNotFoundException : Exception
    {
        public int EntityId { get; set; }
    }
}
