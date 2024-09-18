using ProyectAdmin.Core.Interfaces;

namespace ProyectAdmin.Core.Models
{
    public class Project : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }

}
