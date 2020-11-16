using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Piiii.web.Models;
using Piiii.service;
using Piiii.domain;

using System.Net.Mail;
using Piiii.data;

namespace Piiii.web.Controllers
{
    public class selfevaluationController : Controller
    {
        private Context db = new Context();
        public EvaluationService es;
        public EmployeeService emps;

        public selfevaluationController()
        {
            es = new EvaluationService();
            emps = new EmployeeService();
        }


        public ActionResult Index()
        {
            ViewBag.result = es.GetMany().ToList();
            return View();
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            selfevaluation selfevaluation = es.GetById((int)id);
            if (selfevaluation == null)
            {
                return HttpNotFound();
            }
            return View(selfevaluation);
        }

        // GET: selfevaluation/Create
        public ActionResult Create()
        {
            ViewBag.Employee_id = new SelectList(emps.GetMany(), "id", "name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,improvements,qualities,score,Employee_id")] selfevaluation selfevaluation, string myVar)
        {
            if (ModelState.IsValid)
            {
                MailMessage mm = new MailMessage("ihebo123@gmail.com", "iheb.memmiche@esprit.tn");
                mm.Subject = "A new Self Evaluation is added";
                mm.Body = "Test";
                mm.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.EnableSsl = true;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                
                NetworkCredential nc = new NetworkCredential("ihebo123@gmail.com", "22012201");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = nc;
                smtp.Send(mm);
                selfevaluation.score =Int32.Parse(myVar);
                es.Add(selfevaluation);
                es.Commit();
               
            }

            ViewBag.Employee_id = new SelectList(emps.GetMany(), "id", "name", selfevaluation.Employee_id);
            return View(selfevaluation);
        }

        // GET: selfevaluation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            selfevaluation selfevaluation = es.GetById((int)id);
            if (selfevaluation == null)
            {
                return HttpNotFound();
            }
            ViewBag.Employee_id = new SelectList(emps.GetMany(), "id", "name", selfevaluation.Employee_id);
            return View(selfevaluation);
        }

        // POST: selfevaluation/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, selfevaluation selfevaluation)
        {
            if (ModelState.IsValid)
            {
                selfevaluation se = es.GetById((int)id);
                se.improvements = selfevaluation.improvements;
                se.qualities = selfevaluation.qualities;
                se.score = selfevaluation.score;
                es.Update(se);
                es.Commit();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: selfevaluation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            selfevaluation selfevaluation = es.GetById((int)id);
            if (selfevaluation == null)
            {
                return HttpNotFound();
            }
            return View(selfevaluation);
        }

        // POST: selfevaluation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            selfevaluation selfevaluation = es.GetById(id);
            es.Delete(selfevaluation);
            es.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
