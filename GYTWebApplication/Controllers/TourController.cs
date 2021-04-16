using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GYTWebApplication.Models;
using System.Net.Http;

namespace GYTWebApp.Controllers
{
    public class TourController : Controller
    {
        public IActionResult Index()
        {
            //return View();

            IEnumerable <Tour> tours = null;

            using (var client = new HttpClient ())
            {
                client.BaseAddress = new Uri ("https://localhost:44334/api/");
                var responseTask = client.GetAsync ("Tours");
                responseTask.Wait ();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync <IList <Tour>> ();
                    readJob.Wait ();

                    tours = readJob.Result;
                }
                else
                {
                    // Return the error code here
                    tours = Enumerable.Empty <Tour> ();
                    ModelState.AddModelError (string.Empty, "HELP!!!");
                }
            }
            return View (tours);
        }
    }
}
