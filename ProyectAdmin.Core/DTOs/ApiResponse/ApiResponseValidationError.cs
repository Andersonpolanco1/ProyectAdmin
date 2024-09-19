namespace ProyectAdmin.Core.DTOs.ApiResponse
{
    public class ApiResponseValidationError<T> :ApiResponseBase<T>
    {
        public IDictionary<string, string[]>? ValidationErrors { get; set; }
        public ApiResponseValidationError()
        {
            Success = false;
        }
    }
}
