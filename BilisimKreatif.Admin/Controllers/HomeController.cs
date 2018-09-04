using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BilisimKreatif.Admin.Models;
using BilisimKreatif.Service;
using System.Net.Http;
using BilisimKreatif.Model;

namespace BilisimKreatif.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Route("servis-denemesi")]
        public async Task<IActionResult> Test()
        {
            // C# ile web api çağırıyoruz...
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://localhost:49479/api/customers");
            IEnumerable<Customer> customers = new List<Customer>();
            if (response.IsSuccessStatusCode)
            {
                customers = await response.Content.ReadAsAsync<IEnumerable<Customer>>();
            }
            
            return View(customers);
        }

        public IActionResult Test2()
        {
            return View();
        }

        public IActionResult Test3()
        {
            return View();
        }

        public IActionResult Test4()
        {
            return View();
        }

        public async Task<IActionResult> CallApi(int inputNumber)
        {
            // C# ile web api çağırıyoruz...
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://blockchain.info/tobtc?currency=USD&value=" + inputNumber.ToString());
            string result = "";
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }
            return View("CallApi",model:result);
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
