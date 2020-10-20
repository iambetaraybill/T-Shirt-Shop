using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nest;
using Newtonsoft.Json;
using RestSharp;
using TokenAuthClientMVC.Models;

namespace TokenAuthClientMVC.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //public class JWT
        //{
        //    public string Token { get; set; }
        //}

        [HttpPost]
        public async Task<IActionResult> Index(string uid, string password)
        {
            int id = int.Parse(uid);
            User user = new User { UId = id, Password = password };

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("http://localhost:50316/api/token", content))
                {
                    string token = await response.Content.ReadAsStringAsync();
                    TempData["token"] = token;
                    //ViewBag.Token = token;
                    // var t = TempData["token"].ToString();//1
                    
                }
                 

            }
            var t = TempData["token"].ToString();
            
            if (t != "")
                {
                HttpContext.Session.Clear();
                HttpContext.Session.SetString("uid", uid);
                HttpContext.Session.SetString("password", password);
                 HttpContext.Session.SetString("token", t);
                    return RedirectToAction("ProList", "Pro");

                }
            
               
           
            
            return View();
        }



    }
}

//return RedirectToAction("Index");
//if (TempData["token"] != null)
//{
//    string tok = TempData["token"].ToString();
//    JWT jwt = JsonConvert.DeserializeObject<JWT>(tok);

//    HttpContext.Session.SetString("token", jwt.Token);
//    return RedirectToAction("Index", "Home");
//    //var req = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44367/Home/Index");
//    //req.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tok);
//    //HttpResponseMessage res = await httpClient.SendAsync(req);
//    //if (res.IsSuccessStatusCode) 
//    //{
//    //    return res.;
//    //}

//    //var contentType = new MediaTypeWithQualityHeaderValue("application/json");
//    //httpClient.DefaultRequestHeaders.Accept.Add(contentType);
//    //httpClient.DefaultRequestHeaders.Authorization =
//    //    new AuthenticationHeaderValue("Bearer", tok);
//    //var res = await httpClient.GetAsync("https://localhost:44367/Home/Index");
//    ////return ResponseMessage(res);
//    //return RedirectToAction("Index", "Home");
//}


//[HttpPost]
//public async Task<IActionResult> Index(string uid, string password)
//{
//    int id = int.Parse(uid);
//    User user = new User { UId = id, Password = password };

//    string baseUrl = "http://localhost:49387";
//    HttpClient client = new HttpClient();
//    client.BaseAddress = new Uri(baseUrl);
//    var contentType = new MediaTypeWithQualityHeaderValue
//("application/json");
//    client.DefaultRequestHeaders.Accept.Add(contentType);

//    User userModel = new User();
//    userModel.UserName = "User1";
//    userModel.Password = "pass$word";

//    string stringData = JsonConvert.SerializeObject(userModel);
//    var contentData = new StringContent(stringData,
//System.Text.Encoding.UTF8, "application/json");

//    HttpResponseMessage response = client.PostAsync
//("/api/security", contentData).Result;

//}



