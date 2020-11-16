using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Services;
using System.Web.Services;
using Piiii.data;
using Piiii.domain;
using Piiii.web.Models;

namespace Piiii.web.Controllers
{
    public class TimesheetModelsController : Controller
    {
        private Context db = new Context();
        
        // GET: TimesheetModels
        public ActionResult Index()
        {
            var timesheet = db.timesheet;

            return View(timesheet.ToList());
        }
        
        // GET: TimesheetModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TimesheetModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,conges,heure,jour,poste,employer_id_userId")] timesheet timesheetModel)
        {
            if (ModelState.IsValid)
            {
                var timesheet = db.timesheet;
                timesheet.Add(timesheetModel);
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(timesheetModel);
        }
        
        // GET: TimesheetModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var timesheet = db.timesheet;
            timesheet.Find(id);

            if (timesheet == null)
            {
                return HttpNotFound();
            }
            return View(timesheet);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,conges,heure,jour,poste,employer_id_userId")] TimesheetModel timesheetModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timesheetModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(timesheetModel);
        }
        
        // GET: TimesheetModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var timesheetModel = db.timesheet;
            timesheetModel.Find(id);
                if (timesheetModel == null)
            {
                return HttpNotFound();
            }
            return View(timesheetModel);
        }

        // POST: TimesheetModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var timesheetModel = db.timesheet;
          var  T= timesheetModel.Find(id);
            db.timesheet.Remove(T);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
       
    }
    
}
