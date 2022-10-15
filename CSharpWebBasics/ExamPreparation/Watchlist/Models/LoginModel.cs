using System.ComponentModel.DataAnnotations;

namespace Watchlist.Models
{
    public class LoginModel
    {
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Password { get; set; }
    }
}
