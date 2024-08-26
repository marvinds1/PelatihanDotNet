using System.ComponentModel.DataAnnotations;

namespace Persistence.Dtos.Auth
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Masukkan emailmu")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Masukkan kata sandi")]
        public string Password { get; set; }
    }
}
