using Piiii.web.Models;

using System.Collections.Generic;

using System.Net.Http;
using System.Net.Http.Headers;

using System.Web.Mvc;


namespace Piiii.web.Controllers
{
    public class FormationController : Controller
    {
        // GET: Formation
        public ActionResult Index()
        {
            HttpClient client = new HttpClient();
          //  client.BaseAddress = new Uri("http://localhost:9080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("http://localhost:9080/PiDev-web/rest/Formation").Result;
            if (response.IsSuccessStatusCode)

            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<formationModel>>().Result;


            }
            else
            {
                ViewBag.result = "error";
            }
            return View(ViewBag.result);
        }
    

        // GET: Formation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Formation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Formation/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Formation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Formation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            return View();
        }

        // GET: Formation/Delete/5
      /*  public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Formation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }*/
        [HttpDelete]
        public ActionResult Delete(int id, formationModel d)
        {
            try
            {
                HttpClient Client = new HttpClient();
                Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/xml"));
                HttpResponseMessage response = Client.DeleteAsync("http://localhost:9080/PiDev-web/rest/Formation" + id.ToString()).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");

                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
