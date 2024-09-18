using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectAdmin.Core.DTOs
{
    public class UserCreateDto
    {
        [Required]
        [StringLength(100, ErrorMessage ="El nombre de usuario debe tener al menos 6 caracteres", MinimumLength = 6)] // Valida la longitud del campo
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [PasswordComplexity(MinimumLength = 8)]
        public string Password { get; set; }
    }
}
