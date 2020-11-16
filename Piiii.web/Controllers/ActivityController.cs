using Piiii.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Piiii.web.Controllers
{
    public class ActivityController : Controller
    {
        // GET: Activity
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();

            Client.BaseAddress = new Uri("http://localhost:9080/PiDev2-web/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("rest/activity").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<ActivityModel>>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public ActionResult Create(ActivityModel a)
        {



            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri("http://localhost:9080/PiDev2-web/");
                Client.DefaultRequestHeaders.Accept.Clear();
                Client.DefaultRequestHeaders.Accept.Add(
       new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage response = Client.PostAsJsonAsync<ActivityModel>("rest/activity", a).Result;

                System.Diagnostics.Debug.WriteLine("response :" + response);

                if (response.IsSuccessStatusCode)
                {


                    return RedirectToAction("Index");
                }

                return RedirectToAction("Create");
            }



        }

    }
}