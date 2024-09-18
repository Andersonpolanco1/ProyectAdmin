using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectAdmin.Core.DTOs;
using ProyectAdmin.Core.Utils;

namespace ProyectAdmin.Core.ActionFilters
{
    public class ValidationProblemDetailsResult : IActionResult
    {
        public async Task ExecuteResultAsync(ActionContext context)
        {
            var response = ApiResponseHelper.CreateValidationErrorResponse<object>(context.ModelState, StatusCodes.Status400BadRequest);
            var objectResult = new ObjectResult(response) { StatusCode = StatusCodes.Status400BadRequest };
            await objectResult.ExecuteResultAsync(context);
        }
    }
}
