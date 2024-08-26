using System.ComponentModel.DataAnnotations;

namespace Persistence.Dtos.Auth
{
    public class CreateRoleDTO
    {
        [Required(ErrorMessage = "Masukkan validitas")]
        public string RoleName { get; set; }
    }
}
