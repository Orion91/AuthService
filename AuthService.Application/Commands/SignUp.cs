using System.ComponentModel.DataAnnotations;

namespace AuthService.Application.Commands
{
    public class SignUp : ICommand
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "You must specify password between 6 and 16 characters")]
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }

    }
}