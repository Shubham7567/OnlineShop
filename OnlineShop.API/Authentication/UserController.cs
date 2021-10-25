using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.BLL.Operations.IOperations;
using OnlineShop.Models.EntityModels;
using OnlineShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.API.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthenticate _authenticate;
        private readonly AppSettings _appSettings;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserController(IAuthenticate authenticate, IOptions<AppSettings> appSettings, IHttpContextAccessor httpContextAccessor)
        {
            _authenticate = authenticate;
            _appSettings = appSettings.Value;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpPost("Register")]
        public IActionResult Register(RegisterModel model)
        {
            model.ProfilePic = _httpContextAccessor.HttpContext.Request.Host.Value + "/Images/avatar.png";
            var response = _authenticate.Register(model, _appSettings.Secret);
            if(response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        [HttpPost("login")]
        public IActionResult Login(LoginModel model)
        {
            model.Email = Encoding.UTF8.GetString(Convert.FromBase64String(model.Email));
            model.Password = Encoding.UTF8.GetString(Convert.FromBase64String(model.Password));
            var response = _authenticate.Login(model, _appSettings.Secret);
            if(response != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    { 
                        new Claim(ClaimTypes.Name, Convert.ToString(response.Email)),
                        new Claim(ClaimTypes.Role, Convert.ToString(response.Role))
                    }),
                    Expires = DateTime.Now.AddDays(30),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
                };
                string token = tokenHandler.WriteToken(tokenHandler.CreateJwtSecurityToken(tokenDescriptor));
                response.Token = token;
                return Ok(response);
            }
            return Unauthorized("Login Failed");
        }

    }
}
