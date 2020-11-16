using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Piiii.data;
using Piiii.domain;
using Piiii.web.Models;

namespace Piiii.web.Controllers
{
    public class ProjectModelsController : Controller
    {
        private Context db = new Context();

        // GET: ProjectModels
        public ActionResult Index()
        {
            var project = db.project;
            return View(project.ToList());
        }
        // GET: ProjectModels/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,datedebut,datefin,otherdetai")] project projectModel)
        {
            if (ModelState.IsValid)
            {
                var project = db.project;
                project.Add(projectModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projectModel);
        }
        

        // GET: ProjectModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            project projectModel;
            var project = db.project;
            projectModel = project.Find(id);
            if (projectModel == null)
            {
                return HttpNotFound();
            }
            return View(projectModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,datedebut,datefin,otherdetai,Project_code_id,manager_id_userId")] ProjectModel projectModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projectModel);
        }

       
       // GET: ProjectModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var project = db.project;
               project.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: ProjectModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var project = db.project;
           project p= project.Find(id);
            db.project.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       
        
    }
}
