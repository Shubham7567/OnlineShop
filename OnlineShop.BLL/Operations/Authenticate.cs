using OnlineShop.BLL.Operations.IOperations;
using OnlineShop.BLL.Repository.IRepository;
using OnlineShop.Models.EntityModels;
using OnlineShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Utility;
using System.Net;

namespace OnlineShop.BLL.Operations
{
    public class Authenticate : IAuthenticate
    {
        private readonly IUnitOfWork _unitOfWork;

        public Authenticate(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public UserInfo Login(LoginModel model, String key)
        {
            UserInfo response = new UserInfo();
            try
            {
                var user = _unitOfWork.User.GetFirstOrDefault(x => x.Email == model.Email);
                if (user == null)
                {
                    return null;
                }
                user.Password = CryptoGraphy.DecryptString(user.Password, key);
                if(user.Password != model.Password)
                {
                    return null;
                }
                response.FirstName = user.FirstName;
                response.LastName = user.LastName;
                response.Contact = user.Contact;
                response.Email = user.Email;
                response.ProfilePic = user.ProfilePic;
                response.Role = user.Role;
            }
            catch(Exception ex)
            {
                response = null;
                throw ex;
            }
            return response;
        }

        public Response Register(RegisterModel model,String key)
        {
            Response response = new Response();
            try { 
                if(_unitOfWork.User.GetFirstOrDefault(x => x.Email == model.Email) != null)
                {
                    response.Errors.Add("User with same email already exists");
                }
                if (_unitOfWork.User.GetFirstOrDefault(x => x.Contact == model.Contact) != null)
                {
                    response.Errors.Add("User with same contact already exists");
                }
                if(response.Errors == null)
                {
                    User user = new User();
                    user.Email = model.Email;
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Password = CryptoGraphy.EncryptString(model.Password, key);
                    user.Contact = model.Contact;
                    user.ProfilePic = model.ProfilePic;
                    user.Role = "Admin";
                    response = _unitOfWork.User.Add(user);
                    _unitOfWork.Save();
                    if(!response.IsSuccess)
                    {
                        response.Message = "Failed to register user please check your data.";
                    }
                    else
                    {
                        response.Message = "User registered successfully, please check your mail to verify your registration.";
                        response.IsSuccess = true;
                    }
                }
                else
                {
                    response.IsSuccess = false;
                }
            }
            catch(Exception ex)
            {
                response.Errors.Add(ex.Message);
                response.Message = "Registration interrupted please check your internet connection or data.";
                response.IsSuccess = false;
            }
            return response;
        }
    }
}
