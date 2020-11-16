
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Piiii.service;
using Piiii.domain;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Piiii.web.Models;

namespace MVC.Controllers
{
    public class EmployeController : Controller
    {

        public ActionResult List()
        {

            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:9080/PI-GL-web/rest/employe").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<employe>>().Result;


            }
            else
            {
                ViewBag.result = "erreur";
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
        public async Task<ActionResult> Create(employe t)
        {

            if (ModelState.IsValid)
            {
                HttpClient client = new HttpClient();

                var json = JsonConvert.SerializeObject(t, Formatting.Indented, new JsonSerializerSettings()
                { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                {

                    var result = await client.PostAsync(new Uri("http://localhost:9080/PI-GL-web/rest/employe/"), stringContent);
                }
            }

            return RedirectToAction("List");

        }
    

        //DELETE: Declaration

        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080");
            client.DeleteAsync("http://localhost:9080/PI-GL-web/rest/employe/" + id.ToString()).Result.EnsureSuccessStatusCode();
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
          employe employe = null;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080");

            HttpResponseMessage response = client.GetAsync("http://localhost:9080/PI-GL-web/rest/employe/" + id.ToString()).Result;

            if (response.IsSuccessStatusCode)
            {
                employe = response.Content.ReadAsAsync<employe>().Result;

            }
           
            return View("List");
        }

        [HttpPost]
        public ActionResult Edit(employe e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080");

            EmployeViewModels res = new EmployeViewModels();
            res.userId = e.Id_emp;
            res.nom = e.nom;
            res.prenom = e.prenom;
            res.email = e.email;
           
            res.poste = e.poste;
          
          


            client.PutAsJsonAsync<EmployeViewModels>("http://localhost:9080/PI-GL-web/rest/employe/" + res.userId.ToString(), res).Result.EnsureSuccessStatusCode();


            return RedirectToAction("List");

        }


    }
}