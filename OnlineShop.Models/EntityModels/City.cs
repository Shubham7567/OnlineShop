using OnlineShop.Models.EntityModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models.EntityModels
{
    public class City : CommonFields
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        [MaxLength(4)]
        public string Code { get; set; }
        public List<Location> Locations { get; set; }
    }
}
