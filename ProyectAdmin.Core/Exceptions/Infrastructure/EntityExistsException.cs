using ProyectAdmin.Core.Interfaces;
using System;

namespace ProyectAdmin.Core.Exceptions.Infrastructure
{
    public class EntityExistsException : Exception 
    {
        private const string DEFAULT_MESSAGE = "El registro ya existe";

        public int? Id { get; }
        public IEntity? Entity { get; }

        public EntityExistsException() : base(DEFAULT_MESSAGE)
        {
        }

        public EntityExistsException(int id)
            :this()
        {
            Id = id;
        }

        public EntityExistsException(IEntity entity)
            : this()
        {
            Entity = entity;
            Id = entity.Id;
        }

        public EntityExistsException(int? id, string? message)
            : base(message)
        {
            Id = id;
        }
    }
}
