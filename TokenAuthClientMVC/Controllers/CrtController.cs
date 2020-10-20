using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Cart_MS.DB;
using Cart_MS.DB.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Product_MS.DB.Entities;
using TokenAuthClientMVC.Models;

namespace TokenAuthClientMVC.Controllers
{
    public class CrtController : Controller
    {
        private readonly DataContext DataContext;
        //private readonly Context _context;

        public CrtController(DataContext dataContext)
        {
            DataContext = dataContext;
            //_context = context;
        }


    

        [HttpGet]
        public async Task<IActionResult> AddToCart(int pid, string pn)
        {
            try
            {
                var t = HttpContext.Session.GetString("token").ToString();

                if (t == "")
                {
                    throw new Exception();
                }
                else { }
            }
            catch (Exception e)
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "Login");
            }
            var uid = HttpContext.Session.GetString("uid").ToString();
            int id = int.Parse(uid);
            //User user = DataContext.Users.Find(id);
            Cart cart = new Cart(){ Product = pid, User = id, Name = pn };

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(cart), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:44326/api/cart", content))
                {

                    if (response.IsSuccessStatusCode)
                    { }
                }


            }

            //ViewBag.PName = cart.Name;
            return View();
        }

        public IActionResult ViewCart() 
        {
            try
            {
                var t = HttpContext.Session.GetString("token").ToString();

                if (t == "")
                {
                    throw new Exception();
                }
                else { }
            }
            catch (Exception e)
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "Login");
            }
            var uid = HttpContext.Session.GetString("uid").ToString();
            int id = int.Parse(uid);
            User user = DataContext.Users.Find(id);

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44326/");
            // Add an Accept header for JSON format.    
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // List all Cart Items.    
            HttpResponseMessage response = client.GetAsync("api/Cart").Result;
            if (response.IsSuccessStatusCode)
            {
                var carts = response.Content.ReadAsStringAsync().Result;
                List<Cart> lcarts = JsonConvert.DeserializeObject<List<Cart>>(carts);
                List<Cart> lnew = new List<Cart>();
                foreach (Cart c in lcarts) 
                {
                    if (user.UId == c.User) 
                    {
                        lnew.Add(c);
                    }
                }
                ViewBag.Cra = lnew;
            }
            ViewBag.Ussr = user;
            return View();
        }







    }
}
