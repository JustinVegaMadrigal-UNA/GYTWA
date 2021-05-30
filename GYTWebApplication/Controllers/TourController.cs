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

            //IEnumerable <Tour> tours = null;

            //using (var client = new HttpClient ())
            //{
            //    client.BaseAddress = new Uri ("https://localhost:44334/api/");
            //    var responseTask = client.GetAsync ("Tours");
            //    responseTask.Wait ();

            //    var result = responseTask.Result;

            //    if (result.IsSuccessStatusCode)
            //    {
            //        var readJob = result.Content.ReadAsAsync <IList <Tour>> ();
            //        readJob.Wait ();

            //        tours = readJob.Result;
            //    }
            //    else
            //    {
            //        // Return the error code here
            //        tours = Enumerable.Empty <Tour> ();
            //        ModelState.AddModelError (string.Empty, "HELP!!!");
            //    }
            //}
            //ViewData ["tours"] = tours;

            return View ();
        }

        [HttpGet]
        public JsonResult ListarTours ()
        {
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

            return Json (tours);
        }

        [HttpPost]
        public JsonResult Filtrar (FiltrarViewModel fvm)
        {
            IEnumerable <Tour> tours = null;
            string url = "Pepe";
            bool isFirtUse = false;

            using (var client = new HttpClient ())
            {
                client.BaseAddress = new Uri ("https://localhost:44334/api/");
                
                if (fvm.Destino != "")
                {
                    url = IsFirtUse (isFirtUse, url);
                    isFirtUse = true;

                    url = url + $"Destino='{fvm.Destino}'";
                }
                //if (fvm.Inicio.Date.ToString != "0000/00/01")
                //{
                //    url = IsFirtUse (isFirtUse, url);
                //    isFirtUse = true;

                //    url = url + $"Inicio='{fvm.Inicio.Date}'";
                //}
                //if (fvm.Fin != new DateTime (0, 0, 0))
                //{
                //    url = IsFirtUse (isFirtUse, url);
                //    isFirtUse = true;

                //    url = url + $"Fin='{fvm.Fin.Date}'";
                //}

                var responseTask = client.GetAsync ($"Tours/'{url}'");
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
            //ViewData ["tours"] = tours;
            return Json (tours);
        }

        internal string IsFirtUse (bool isFirtUse, string url)
        {
            return isFirtUse ? url + "?" : url + "&";
        }
    }
}
