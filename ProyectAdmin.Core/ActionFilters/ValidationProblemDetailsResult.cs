using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectAdmin.Core.Utils;

namespace ProyectAdmin.Core.ActionFilters
{
    public class ValidationProblemDetailsResult : IActionResult
    {
        public async Task ExecuteResultAsync(ActionContext context)
        {
            var erors = ModelStateMap.MapModelStateToValidationErrorResponse(context.ModelState);
            var objectResult = new ObjectResult(erors) { StatusCode = StatusCodes.Status400BadRequest };
            await objectResult.ExecuteResultAsync(context);
        }
    }
}
