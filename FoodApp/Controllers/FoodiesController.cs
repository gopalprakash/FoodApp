using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FoodApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FoodApp.Controllers
{
    public class FoodiesController : Controller
    {

        public string baseUrl= "https://localhost:44302/api/Foodies/";
        public HttpClient CallApi()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress =  new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> FoodiesProfileAsync()
        {
            List<ModelFoodie> foodies = new List<ModelFoodie>();
            var client = CallApi();
            var response =await client.GetAsync(baseUrl+"GetProfiles");
            if(response.IsSuccessStatusCode)
            {
                foodies = JsonConvert.DeserializeObject<List<ModelFoodie>>(await response.Content.ReadAsStringAsync());
                ViewBag.Foodies = foodies;
            }
            else
            {

            }
            return View();
        }
    }
}