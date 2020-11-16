using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Piiii.web.Models;

namespace Piiii.web.Controllers
{
    public class EvaluationController : Controller
    {
        // GET: Evaluation
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();

            Client.BaseAddress = new Uri("http://localhost:9080/PiDev-web/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("rest/evaluation").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<evaluation360Model>>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080/PiDev-web/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("rest/evaluation/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<evaluation360Model>>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }
            return View();

        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:9080/PiDev-web/");
                client.DeleteAsync("rest/evaluation/" + id).ContinueWith((postTask) => postTask.Result.IsSuccessStatusCode);
                return View();
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(evaluation360Model e)
        {



            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri("http://localhost:9080/PiDev-web/");
                Client.DefaultRequestHeaders.Accept.Clear();
                Client.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage response = Client.PostAsJsonAsync<evaluation360Model>("rest/evaluation", e).Result;

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