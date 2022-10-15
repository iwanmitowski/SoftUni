using System.ComponentModel.DataAnnotations;

namespace Watchlist.Models
{
    public class RegisterModel
    {
        public string? ReturnUrl { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(60)]
        public string Email { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        [Compare(nameof(ConfirmPassword))]
        public string Password { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
