using OnlineShop.BLL.Repository.IRepository;
using OnlineShop.DAL.Data;
using OnlineShop.Models.EntityModels;
using OnlineShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BLL.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationContext _db;
        public UserRepository(ApplicationContext db):base(db)
        {
            _db = db;
        }
        public Response Update(User user)
        {
            Response response = new Response();
            try
            {
                var objFromDb = _db.User.FirstOrDefault(u => u.Id == user.Id);
                if (objFromDb != null)
                {
                    objFromDb.Email = user.Email;
                    objFromDb.FirstName = user.FirstName;
                    objFromDb.LastName = user.LastName;
                    objFromDb.Contact = user.Contact;
                    objFromDb.ProfilePic = user.ProfilePic;
                }
                response.IsSuccess = true;
            }
            catch(Exception ex)
            {
                response.Errors.Add(ex.Message);
                response.IsSuccess = false;
            }
            return response;
        }
    }
}
