
using System;

using System.Linq;

using System.Web.Mvc;
using PagedList.Mvc;

using Piiii.web.Models;
using Piiii.domain;
using Piiii.service;
using PagedList;

namespace Piiii.web.Controllers
{
    public class QuizController : Controller
    {
        public QuizService qz;
        public FormationService fs;

        public QuizController()
        {
            qz = new QuizService();
        }

        // GET: Quiz
        public ActionResult Index(int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(qz.GetAll().ToPagedList(pageNumber,pageSize));
        }
        [HttpPost]
        public ActionResult Index(string filtre)
        {
            var list = qz.GetMany();

            if (!String.IsNullOrEmpty(filtre))
            { list = list.Where(m => m.QuizName.ToString().Contains(filtre)).ToList(); }
            return View(list);
        }

        // GET: Quiz/Details/5
        public ActionResult Details(int id)
        {
            quiz q = qz.GetById(id);
            if (q == null)
            {
                return HttpNotFound();
            }

            return View(q);
        }

        // GET: Quiz/Create
        public ActionResult Create()
        {
            fs = new FormationService();
            var Formations = fs.GetMany().Where(f=>f.niveauobt.Equals("master"));
            ViewBag.formation_id_for = new SelectList(Formations, "id_for", "nom_for");

            return View();
        }

        // POST: Quiz/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(quizModel qzv)
        {
            try
            {
              //  if (ModelState.IsValid)
              //  {
                    quiz q = new quiz();
                    q.QuizName = qzv.QuizName;
                    //   q.formation = (System.Collections.Generic.ICollection<Data.formation>)qzv.formation;
                    q.id_Quiz = qzv.id_Quiz;
                    q.formation_id_for = qzv.formation_id_for;
                
                    qz.Add(q);
                    qz.Commit();
                   // return RedirectToAction("Create", "Question", new { id = "id_Quiz", otherParam = "foo" });
              //  }
               return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Quiz/Edit/5
        public ActionResult Edit(int id)

        {
            fs = new FormationService();
            var Formations = fs.GetMany().Where(f => f.niveauobt.Equals("master"));
            ViewBag.formation_id_for = new SelectList(Formations, "id_for", "nom_for", fs.GetById((int)qz.GetById(id).formation_id_for).nom_for);
            return View(qz.GetById(id));
        }

        // POST: Quiz/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, quizModel q)
        {
            try
            {
                // TODO: Add update logic here
                quiz qq = new quiz();
                qq = qz.GetById(id);
                qq.QuizName = q.QuizName;
                qq.id_Quiz = q.id_Quiz;
                qq.formation_id_for = q.formation_id_for;
                qz.Commit();
            

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Quiz/Delete/5
        public ActionResult Delete(int id)
        {
            quiz q = qz.GetById(id);
            if (q == null)
            {
                return HttpNotFound();
            }

            return View(q);
        }

        // POST: Quiz/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, quiz q)
        {
            try
            {
                // TODO: Add delete logic here
               q = qz.GetById(id);
                qz.Delete(q);
                qz.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
