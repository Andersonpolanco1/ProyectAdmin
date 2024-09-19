
namespace ProyectAdmin.Core.Exceptions.Infrastructure
{
    public class SaveChangesException : Exception
    {
        private const string DEFAULT_MESSAGE = "Ha ocurrido un error guardando los cambios";

        public SaveChangesException():base(DEFAULT_MESSAGE)
        {

        }

        public SaveChangesException(string message) :base(message)
        {
            
        }
    }
}
