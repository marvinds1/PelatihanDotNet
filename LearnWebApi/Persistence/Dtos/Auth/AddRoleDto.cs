using System.ComponentModel.DataAnnotations;
namespace Persistence.Dtos.Auth
{
    public class AddRoleToUserDto
    {
        [Required(ErrorMessage = "Masukkan ID pengguna")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Masukkan Role")]
        public string Role { get; set; }
    }
}
