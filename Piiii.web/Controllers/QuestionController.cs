
using System;
using System.Linq;

using System.Web.Mvc;
using Piiii.web.Models;
using Piiii.domain;
using Piiii.service;

namespace Piiii.web.Controllers
{
    public class QuestionController : Controller
    {
        public QuizService qz;
        public AnswerService ans;
        public QuestionService qts;
        public QuestionController()
        {

            qts = new QuestionService();

        }
        // GET: Question
        public ActionResult Index(int id)
        {
            return View(qts.GetMany().Where(k=>k.quiz_id_Quiz==id));
        }

        [HttpPost]
        public ActionResult Index(string filtre)
        {
            var list = qts.GetMany();

            if (!String.IsNullOrEmpty(filtre))
            { list = list.Where(m => m.quiz.QuizName.ToString().Contains(filtre)).ToList(); }
            return View(list);
        }

        // GET: Question/Details/5
        public ActionResult Details(int id)
        {
            question q = qts.GetById(id);
            if (q == null)
            {
                return HttpNotFound();
            }

            return View(q);
        }

        // GET: Question/Create/5
        public ActionResult Create(int id)
        {
           
            qz = new QuizService();
        
            var Quizs = qz.GetMany().Where(k => k.id_Quiz == id);
            ViewBag.quiz_id_Quiz = new SelectList(Quizs, "id_Quiz", "QuizName");

            return View();
        }

        // POST: Question/Create
        [HttpPost]
        public ActionResult Create(questionModel qm )
        {
            try
            {
                // TODO: Add insert logic here
                question q = new question();
                q.question_name = qm.question_name;
                q.question_description = qm.question_description;
                q.quiz_id_Quiz = qm.quiz_id_Quiz;
                q.id_Question = qm.id_Question;

                
                    qts.Add(q);
                    qts.Commit();

                   
                    return RedirectToAction("Index" ,new { id = q.quiz_id_Quiz });
             
            }
            catch
            {
                return View();
            }
        }

        // GET: Question/Edit/5
        public ActionResult Edit(int id)
        {
            qz = new QuizService();
            var Quizs = qz.GetMany().Where(k => k.id_Quiz == id);
            ViewBag.quiz_id_Quiz = new SelectList(Quizs, "id_Quiz", "QuizName", qz.GetById((int)qts.GetById(id).quiz_id_Quiz).QuizName);
            return View(qts.GetById(id));
        }

        // POST: Question/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, questionModel q)
        {
            try
            {
                var qid = id;
                question qq = new question();
                qq = qts.GetById(id);
                qq.question_name = q.question_name;
                qq.question_description = q.question_description;
                qq.id_Question = q.id_Question;
                qq.quiz_id_Quiz = q.quiz_id_Quiz;
                qts.Commit();
                return RedirectToAction("Index", new { id=qid});
            }
            catch
            {
                return View();
            }
        }

        // GET: Question/Delete/5
        public ActionResult Delete(int id)
        {
            question q = qts.GetById(id);
            if (q == null)
            {
                return HttpNotFound();
            }

            return View(q);
        }

        // POST: Question/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, question q)
        {
            try
            {
                // TODO: Add delete logic here
                q = qts.GetById(id);
                var idq = q.quiz_id_Quiz;
                qts.Delete(q);
                qts.Commit();
                return RedirectToAction("Index" ,new { id= idq});
            }
            catch
            {
                return View();
            }
        }
    }
}
