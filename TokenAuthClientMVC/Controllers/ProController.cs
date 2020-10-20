using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Product_MS.DB.Entities;
using TokenAuthClientMVC.Models;

namespace TokenAuthClientMVC.Controllers
{
    public class ProController : Controller
    {
        public DataContext DataContext { get; }

        public ProController(DataContext dataContext)
        {
            DataContext = dataContext;
        }
        //[Authorize]
        public IActionResult ProList()
        {
            try
            {
                var t = HttpContext.Session.GetString("token").ToString();

                if (t == "")
                {
                    throw new Exception();
                }
                else {}
            }
            catch(Exception e) 
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "Login");
            }

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:62434/");
            // Add an Accept header for JSON format.    
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // List all Names.    
            HttpResponseMessage response = client.GetAsync("api/Product").Result;
            if (response.IsSuccessStatusCode)
            {
                var products = response.Content.ReadAsStringAsync().Result;
                List<Product> product = JsonConvert.DeserializeObject<List<Product>>(products);
                ViewBag.Pro = product; 
            }
            
            var uid = HttpContext.Session.GetString("uid").ToString();
            int id = int.Parse(uid);
            User user = DataContext.Users.Find(id);
            ViewBag.User = user;
            return View();
        }

        public IActionResult LogOut() 
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");

        }
    }
}
