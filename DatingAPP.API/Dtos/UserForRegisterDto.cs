using System.ComponentModel.DataAnnotations;

namespace DatingAPP.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "You must specify password betwwen 4 and 8 characters")]
        public string Password {get; set;}
        
    }
}