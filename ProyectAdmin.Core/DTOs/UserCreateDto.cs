using System.ComponentModel.DataAnnotations;

namespace ProyectAdmin.Core.DTOs
{
    public class UserCreateDto
    {
        [Required]
        [StringLength(100, ErrorMessage ="El nombre de usuario debe tener al menos 6 caracteres", MinimumLength = 6)] 
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress(ErrorMessage ="Debe ser un correo en un formato válido.")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [PasswordComplexity(MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;
    }
}
