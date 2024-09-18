
using ProyectAdmin.Core.Interfaces;

namespace ProyectAdmin.Core.Models
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Task> TareasAsignadas { get; set; }
    }
}
