using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TokenAuthClientMVC.Models;

namespace TokenAuthClientMVC.Controllers
{
    public class SignupController : Controller
    {
        private readonly DataContext _dataContext;

        public SignupController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string name, string password)
        {
            User user = new User { Name = name, Password = password };
            try
            {
                user = _dataContext.Users.Add(user).Entity;
                _dataContext.SaveChanges();
                ViewBag.Name = string.Format("Your User Id: {0}", user.UId);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
            return View();
        }
    }
}
