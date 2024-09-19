namespace ProyectAdmin.Core.DTOs.ApiResponse
{
    public class ApiResponseError<T> :ApiResponseBase<T>
    {
        public string? Message { get; set; }

        public ApiResponseError()
        {
            Success = false;
        }
    }
}
