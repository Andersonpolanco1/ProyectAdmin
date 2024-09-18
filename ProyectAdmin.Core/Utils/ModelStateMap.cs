using Microsoft.AspNetCore.Mvc.ModelBinding;
using ProyectAdmin.Core.DTOs;

namespace ProyectAdmin.Core.Utils
{
    public static class ModelStateMap
    {
        public static ValidationErrorResponse MapModelStateToValidationErrorResponse(ModelStateDictionary modelState)
        {
            var errors = new Dictionary<string, string[]>();

            foreach (var state in modelState)
            {
                var fieldName = state.Key;
                var errorMessages = state.Value.Errors
                    .Select(e => e.ErrorMessage)
                    .ToArray();

                if (errorMessages.Length != 0)
                    errors[fieldName] = errorMessages;
            }

            return new ValidationErrorResponse(errors);
        }
    }
}
