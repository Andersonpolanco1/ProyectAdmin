using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ProyectAdmin.Core.DTOs;


namespace ProyectAdmin.Core.Utils
{
    public static class ApiResponseHelper
    {
        public static ApiResponse<T> CreateSuccessResponse<T>(T data, int statusCode = StatusCodes.Status200OK)
        {
            return new ApiResponse<T>
            {
                Success = true,
                StatusCode = statusCode,
                Data = data
            };
        }

        public static ApiResponse<T> CreateErrorResponse<T>(string message, int statusCode)
        {
            return new ApiResponse<T>
            {
                Success = false,
                StatusCode = statusCode,
                Message = message
            };
        }

        public static ApiResponse<T> CreateValidationErrorResponse<T>(ModelStateDictionary modelState, int statusCode = StatusCodes.Status400BadRequest)
        {
            var errors = modelState
                .Where(ms => ms.Value.Errors.Count > 0)
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );

            return new ApiResponse<T>
            {
                Success = false,
                StatusCode = statusCode,
                Message = "Ha ocurrido uno o varios errores de validación.",
                ValidationErrors = errors
            };
        }
    }

}
