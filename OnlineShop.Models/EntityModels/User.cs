using OnlineShop.Models.EntityModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models.EntityModels
{
    public class User : CommonFields
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Email { get; set; }
        public string Password { get; set; }
        [Required]
        [MaxLength(20)]
        public string Contact { get; set; }
        [Required]
        [MaxLength(200)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(200)]
        public string LastName { get; set; }
        [Required]
        public string ProfilePic { get; set; }
        [Required]
        [MaxLength(200)]
        public string Role { get; set; }
    }
}
