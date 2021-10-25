using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models.ViewModels
{
    public class RegisterModel
    {
        [Required]
        [MaxLength(200)]
        public string Email { get; set; }
        [Required]
        [MaxLength(200)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(200)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(200)]
        [MinLength(8)]
        public string Password { get; set; }
        [Required]
        [MaxLength(20)]
        public string Contact { get; set; }
        public string ProfilePic { get; set; }
    }
}
