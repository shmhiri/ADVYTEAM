using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Piiii.service;
using Piiii.domain;


namespace MVC.Controllers
{
    public class ManagementController : Controller
    {


        // GET: Index
        public ActionResult Index()
        {

            IEnumerable<employe> res = new List<employe>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("/MapLevio-web/rest/employe").Result;

            return View();






        }
    }
}