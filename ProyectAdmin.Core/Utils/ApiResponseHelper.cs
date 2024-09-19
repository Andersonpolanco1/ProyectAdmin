using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ProyectAdmin.Core.DTOs;
using ProyectAdmin.Core.DTOs.ApiResponse;


namespace ProyectAdmin.Core.Utils
{
    public static class ApiResponseHelper
    {
        public static ApiResponseOk<T> CreateSuccessResponse<T>(T data, int statusCode = StatusCodes.Status200OK)
        {
            return new ApiResponseOk<T>
            {
                StatusCode = statusCode,
                Data = data
            };
        }

        public static ApiResponseError<T> CreateErrorResponse<T>(string message, int statusCode)
        {
            return new ApiResponseError<T>
            {
                StatusCode = statusCode,
                Message = message
            };
        }

        public static ApiResponseValidationError<T> CreateValidationErrorResponse<T>(ModelStateDictionary modelState, int statusCode = StatusCodes.Status400BadRequest)
        {
            var errors = modelState
                .Where(ms => ms.Value.Errors.Count > 0)
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );

            return new ApiResponseValidationError<T>
            {
                StatusCode = statusCode,
                ValidationErrors = errors
            };
        }
    }

}
