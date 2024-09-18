﻿
using ProyectAdmin.Core.Interfaces;

namespace ProyectAdmin.Core.Models
{
    public class Task : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public Enums.TaskStatus Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }

        public int ProjectId { get; set; }
        public int? AssignedTo { get; set; }

        public Project Project { get; set; }
        public User? User { get; set; }
    }
}
