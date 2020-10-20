using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TokenAuthClientMVC.Models;

namespace TokenAuthClientMVC.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class TokenController : ControllerBase
    //{
    //}

    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {

        private IConfiguration _config;
        private readonly DataContext _dataContext;
        //public static DataContext context = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        public TokenController(IConfiguration config, DataContext dataContext)
        {
            _config = config;
            _dataContext = dataContext;
        }


        [HttpPost]
        public string Login([FromBody] User login)
        {

            string response = "";
            //login.UId = 1;
            //login.Name = "Arpan";
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                //Console.WriteLine("ok");
                response = tokenString; 
                //Console.WriteLine("ok");

            }

            return response;
        }

        private string GenerateJSONWebToken(User userInfo)
        {
            

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public User AuthenticateUser(User login)
        {
            User user = null;
            try
            {
                user = _dataContext.Users.FirstOrDefault(user => user.UId == login.UId && user.Password == login.Password);

            }
            catch (Exception ex)
            {
                return user;
            }
            

            //Demo
            //if (login.Name == "Arpan" && login.Password == "Arpan123")
            //{
            //    //user = new User { Id = "Arpan", Password = "Arpan123" };
            //    user = new User {UId=1, Password = "Arpan123", Name = "Arpan" };
            //}
            //Validate the User Credentials 


            return user;
        }

    }
}
