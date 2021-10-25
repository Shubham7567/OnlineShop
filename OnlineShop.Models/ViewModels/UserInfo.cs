using OnlineShop.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models.ViewModels
{
    public class UserInfo:User
    {
        public string Token { get; set; }
    }
}
