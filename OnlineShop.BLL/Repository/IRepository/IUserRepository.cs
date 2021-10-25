using OnlineShop.Models.EntityModels;
using OnlineShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BLL.Repository.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        Response Update(User user);
    }
}
