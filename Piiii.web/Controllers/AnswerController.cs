
using Piiii.web.Models;
using Piiii.domain;
using Piiii.service;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Piiii.web.Controllers
{
    public class AnswerController : Controller
    {
        public QuizService qz;
        public AnswerService ans;
        public QuestionService qts;

        public AnswerController()
        {
            ans = new AnswerService();
        }
        // GET: Answer
        public ActionResult Index(int id)
        {
            return View(ans.GetMany().Where(a => a.question_id_Question==id));
        }
        [HttpPost]
        public ActionResult Index(string filtre)
        {
            var list = ans.GetMany();

            if (!String.IsNullOrEmpty(filtre))
            { list = list.Where(m => m.answer_name.ToString().Contains(filtre)).ToList(); }
            return View(list);
        }

        // GET: Answer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Answer/Create
        public ActionResult Create(int id)
        {
            qts = new QuestionService();
            var Questions = qts.GetMany().Where(a=>a.id_Question.Equals(id));
            ViewBag.question_id_Question = new SelectList(Questions, "id_Question", "question_name");

            return View();
        }

        // POST: Answer/Create
        [HttpPost]
        public ActionResult Create(answerModel ansm)
        {
            try
            {
                int i = 0;
                //while (i < 3)
                //{
                    answer q = new answer();
                    q.answer_name = ansm.answer_name;
                    //   q.formation = (System.Collections.Generic.ICollection<Data.formation>)qzv.formation;
                    q.question_id_Question = ansm.question_id_Question;
                    q.id_Answer = ansm.id_Answer;
                    q.flag = ansm.flag;

                    ans.Add(q);
                    ans.Commit();
                    i++;
                  //  return RedirectToAction("Create");
                //}
                return RedirectToAction("Index", new { id = q.question_id_Question });
            }
            catch
            {
                return View();
            }
        }

        // GET: Answer/Edit/5
        public ActionResult Edit(int id)
        {
            qts = new QuestionService();
            var Questions = qts.GetMany().Where(a => a.id_Question == id);
            ViewBag.question_id_Question = new SelectList(Questions, "id_Question", "question_name", qts.GetById((int)ans.GetById(id).question_id_Question).question_name);
            return View(ans.GetById(id));
        }

        // POST: Answer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, answerModel q)
        {
            try
            {
                var qid = id;
                answer qq = new answer();
                qq = ans.GetById(id);
                qq.answer_name = q.answer_name;
                qq.id_Answer = id;
                qq.flag = q.flag;
                ans.Commit();
                return RedirectToAction("Index", new { id = qid });
            }
            catch
            {
                return View();
            }
        }

        // GET: Answer/Delete/5
        public ActionResult Delete(int id)
        {
            answer q = ans.GetById(id);
            if (q == null)
            {
                return HttpNotFound();
            }

            return View(q);
        }

        // POST: Answer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, answer q)
        {
            try
            {
                q = ans.GetById(id);
                var idq = q.question_id_Question;
                ans.Delete(q);
                ans.Commit();
                return RedirectToAction("Index" , new {id = idq });
            }
            catch
            {
                return View();
            }
        }
    }
}
