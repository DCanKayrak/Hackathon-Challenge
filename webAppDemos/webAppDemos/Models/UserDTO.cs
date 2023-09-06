using System.ComponentModel.DataAnnotations;

namespace webAppDemos.Models
{
    public class UserDTO
    {
        [Required]
        public required string email { get; set; }
        [Required]
        public required string password { get; set; }
    }
}
