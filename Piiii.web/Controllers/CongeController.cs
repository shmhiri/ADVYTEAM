using Piiii.service;
using Piiii.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;

namespace MVC.Controllers
{
    public class CongeController : Controller
    {
        public ActionResult list()
        {
            HttpClient p = new HttpClient();
            p.BaseAddress = new Uri("http://localhost:9080");
            p.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = p.GetAsync("PI-GL-web/rest/conge").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<conge>>().Result;
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
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(conge t)
        {

            if (ModelState.IsValid)
            {
                HttpClient client = new HttpClient();

                var json = JsonConvert.SerializeObject(t, Formatting.Indented, new JsonSerializerSettings()
                { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                {

                    var result = await client.PostAsync(new Uri("http://localhost:9080/pidev-web/rest/conge/"), stringContent);
                }
            }

            return RedirectToAction("list");

        }




    }
}