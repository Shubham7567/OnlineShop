using OnlineShop.Models.EntityModels;
using OnlineShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BLL.Operations.IOperations
{
    public interface IAuthenticate
    {
        public Response Register(RegisterModel model, String key);
        public UserInfo Login(LoginModel model, String key);

    }
}
