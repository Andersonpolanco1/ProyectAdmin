

using ProyectAdmin.Core.DTOs.ApiResponse;

namespace ProyectAdmin.Core.DTOs
{
    public class ApiResponseOk<T> : ApiResponseBase<T>
    {
        public T? Data { get; set; }

        public ApiResponseOk()
        {
            Success = true;
        }
    }
}
