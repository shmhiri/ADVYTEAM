using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Piiii.data;
using Piiii.domain;

namespace Piiii.web.Controllers
{
    public class missionexpensesController : Controller
    {
        private Context db = new Context();

        // GET: missionexpenses
        public ActionResult Index()
        {
            var missionexpenses = db.missionexpenses.Include(m => m.mission).Include(m => m.user);
            return View(missionexpenses.ToList());
        }

        // GET: missionexpenses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            missionexpenses missionexpenses = db.missionexpenses.Find(id);
            if (missionexpenses == null)
            {
                return HttpNotFound();
            }
            return View(missionexpenses);
        }

        // GET: missionexpenses/Create
        public ActionResult Create()
        {
            ViewBag.mission_refrence = new SelectList(db.mission, "refrence", "description");
            ViewBag.user_userId = new SelectList(db.user, "userId", "email");
            return View();
        }

        // POST: missionexpenses/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "refrence,isApproved,totalRecovered,mission_refrence,cost,date,description,image,kilomtrage,totalCost,type,user_userId")] missionexpenses missionexpenses, HttpPostedFileBase file,int? id)
        {
         

            if (file != null)
            {
                string fileName = Path.GetFileName(file.FileName);
                string path = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                file.SaveAs(path);
            }
            missionexpenses.user_userId = 2;
            missionexpenses.mission_refrence = id;
            missionexpenses.image = file.FileName;
            missionexpenses.date = System.DateTime.Now;
          
           
                db.missionexpenses.Add(missionexpenses);
                db.SaveChanges();
                return RedirectToAction("Index");
          
           

            //ViewBag.mission_refrence = new SelectList(db.mission, "refrence", "description", missionexpenses.mission_refrence);
            //ViewBag.user_userId = new SelectList(db.user, "userId", "email", missionexpenses.user_userId);
            //return View(missionexpenses);
        }

        // GET: missionexpenses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            missionexpenses missionexpenses = db.missionexpenses.Find(id);
            if (missionexpenses == null)
            {
                return HttpNotFound();
            }
            ViewBag.mission_refrence = new SelectList(db.mission, "refrence", "description", missionexpenses.mission_refrence);
            ViewBag.user_userId = new SelectList(db.user, "userId", "email", missionexpenses.user_userId);
            return View(missionexpenses);
        }

        // POST: missionexpenses/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "refrence,isApproved,totalRecovered,mission_refrence,cost,date,description,image,kilomtrage,totalCost,type,user_userId")] missionexpenses missionexpenses,HttpPostedFileBase file)
        {
            if (file != null)
            {
                string fileName = Path.GetFileName(file.FileName);
                string path = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                file.SaveAs(path);
            }
          
            missionexpenses.image = file.FileName;
            missionexpenses.date = System.DateTime.Now;

          //  if (ModelState.IsValid)
            //{
                db.Entry(missionexpenses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Expances");
           // }
            //ViewBag.mission_refrence = new SelectList(db.mission, "refrence", "description", missionexpenses.mission_refrence);
            //ViewBag.user_userId = new SelectList(db.user, "userId", "email", missionexpenses.user_userId);
            //return View(missionexpenses);
        }

        // GET: missionexpenses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            missionexpenses missionexpenses = db.missionexpenses.Find(id);
            if (missionexpenses == null)
            {
                return HttpNotFound();
            }
            return View(missionexpenses);
        }

        // POST: missionexpenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            missionexpenses missionexpenses = db.missionexpenses.Find(id);
            db.missionexpenses.Remove(missionexpenses);
            db.SaveChanges();
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
