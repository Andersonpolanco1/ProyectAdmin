using System.ComponentModel.DataAnnotations;

namespace ProyectAdmin.Core.DTOs.Models.User
{
    public class UserLoginRequest
    {
        [Required]
        [EmailAddress(ErrorMessage = "Debe ser un correo en un formato válido.")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [PasswordComplexity(MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;
    }
}
