using System.ComponentModel.DataAnnotations;

namespace CrecheApp.Domain.Model
{
    public class AuthenticateRequestModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
