using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Piiii.service;
using Piiii.web.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Piiii.web.Controllers
{
    public class Missioncontroller : Controller
    {
        public ExpancesService ExpS { get; set; }


        public Missioncontroller()
        {
            ExpS = new ExpancesService();

        }

        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();

            Client.BaseAddress = new Uri("http://localhost:9080/PiDev-web/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("api/mission").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<mission>>().Result;
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


        public ActionResult Details(int? id)
        {
            HttpClient Client = new HttpClient();

            Client.BaseAddress = new Uri("http://localhost:9080/PiDev-web/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync($"api/mission/{id}").Result;
            System.Diagnostics.Debug.WriteLine("response :" + response);
         
                ViewBag.result = response.Content.ReadAsAsync <mission>().Result;
                mission m = ViewBag.result;
                return View(m);
           
            
        }


        public ActionResult recherche(String recherche)
        
        {
            HttpClient Client = new HttpClient();

            Client.BaseAddress = new Uri("http://localhost:9080/PiDev-web/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (!String.IsNullOrEmpty(recherche))
            {
                HttpResponseMessage response = Client.GetAsync($"api/mission/serch/{recherche}").Result;
                System.Diagnostics.Debug.WriteLine("response :" + response);

                if (response.IsSuccessStatusCode)
                {
                    ViewBag.result = response.Content.ReadAsAsync<IEnumerable<mission>>().Result;
                }
                else
                {
                    ViewBag.result = "error";
                }
            }
              
                return View();

            }


        

        [HttpPost]
        public ActionResult Create(mission m)
        {
            string s = "Availbale";
        
           
            m.date = DateTime.Today;
      
            m.state = s;
       
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri("http://localhost:9080/PiDev-web/");
                Client.DefaultRequestHeaders.Accept.Clear();
                Client.DefaultRequestHeaders.Accept.Add(
       new MediaTypeWithQualityHeaderValue("application/json"));

        
                HttpResponseMessage response = Client.PostAsJsonAsync<mission>("api/mission", m).Result;

                System.Diagnostics.Debug.WriteLine("response :" + response);

                if (response.IsSuccessStatusCode)
                {


                    return RedirectToAction("Index");
                }

                return RedirectToAction("Create");
            }

        

    }
        public ActionResult delete (int? id)
        {
            HttpClient Client = new HttpClient();

            Client.BaseAddress = new Uri("http://localhost:9080/PiDev-web/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.DeleteAsync($"api/mission/{id}").Result;
            System.Diagnostics.Debug.WriteLine("response :" + response);
            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return RedirectToAction("Details");



        }
        [HttpGet]
        public ActionResult update(int? id)
        {
            HttpClient Client = new HttpClient();

            Client.BaseAddress = new Uri("http://localhost:9080/PiDev-web/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync($"api/mission/{id}").Result;
            System.Diagnostics.Debug.WriteLine("response :" + response);

            ViewBag.result = response.Content.ReadAsAsync<mission>().Result;
            mission m = ViewBag.result;
            return View(m);


        }
        [HttpPost]
        public ActionResult update(int? id, mission m)
        {
            string s = "Availbale";
         
           
            m.date = DateTime.Today;
           
            m.state = s;
   
            HttpClient Client = new HttpClient();

            Client.BaseAddress = new Uri("http://localhost:9080/PiDev-web/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.PutAsJsonAsync<mission>($"api/mission/{id}",m).Result;
            System.Diagnostics.Debug.WriteLine("response :" + response);
            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return RedirectToAction("update");

         
        }
     

        [HttpGet]
        public ActionResult missionExpnce(int? id,string filtre, string lama)
        {

            ViewBag.ID = id;

          //  var posts = ExpS.GetMany();
            var posts = ExpS.GetexpanssessByMission((int)id);
            if (!String.IsNullOrEmpty(filtre))
            { posts = posts.Where(m => m.description.ToString().Contains(filtre) || m.cost.ToString().Contains(filtre) || m.kilomtrage.ToString().Contains(filtre)).ToList(); }
            if (!String.IsNullOrEmpty(lama))
            {
                posts = posts.Where(m => m.type.ToString().Contains(lama)).ToList();
            }
            //   return View(posts);
         
            return View(posts);
           
        }


    }

}
