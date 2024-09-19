namespace ProyectAdmin.Core.DTOs.ApiResponse
{
    public abstract class ApiResponseBase<T>
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }
    }
}
