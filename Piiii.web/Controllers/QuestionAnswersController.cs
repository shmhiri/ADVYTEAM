

using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;
using PagedList;
using System.Diagnostics;
using Piiii.web.Models;
using Piiii.domain;
using Piiii.service;

namespace Piiii.web.Controllers
{
    public class QuestionAnswersController : Controller
    {
        public AnswerService ans;
        public QuestionService qts;
        public QuizService qz;
        public float score_quest = 0;
        public float score = 0;


        public QuestionAnswersController()
        {
            qz = new QuizService();
            qts = new QuestionService();
            ans = new AnswerService();

        }

        // GET: QuestionAnswers
        public ActionResult Index(int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(qz.GetAll().ToPagedList(pageNumber, pageSize));
        }
        [HttpPost]
        public ActionResult Index(string filtre)
        {
            var list = qz.GetMany();

            if (!String.IsNullOrEmpty(filtre))
            { list = list.Where(m => m.QuizName.ToString().Contains(filtre)).ToList(); }
            return View(list);
        }
        // GET: QuestionAnswers/Details/5
        public ActionResult Details(int id)
        {

            quiz q = qz.GetById(id);
            if (q == null)
            {
                return HttpNotFound();
            }

            return View(q);

            //return View(qz.GetById(id));
        }


        // GET: QuestionAnswers/Create
        public ActionResult loadQuiz(int id)
        {
            QuizQuestionAnswers qqa  = new QuizQuestionAnswers();
            qqa.quizId = id;
            quiz quiz = qz.GetById(id);

            var questions = qts.GetMany().Where(x => x.quiz_id_Quiz.Equals(quiz.id_Quiz));
            
            qqa.Questions = new List<questionModel>();
            qqa.answers = new List<answerModel>();
            foreach (question quest in questions)
                {
                    questionModel questionModel = new questionModel();
                    questionModel.id_Question = quest.id_Question;
                    questionModel.question_name = quest.question_name;
                    questionModel.question_description = quest.question_description;
                  questionModel.userchoice = null;

                var answers = ans.GetMany().Where(x => x.question_id_Question.Equals(quest.id_Question));


                    foreach (answer answ in answers)
                    {
                        answerModel answerModel = new answerModel();
                        answerModel.id_Answer = answ.id_Answer;
                        answerModel.question_id_Question = answ.question_id_Question;
                        answerModel.answer_name = answ.answer_name;
                        answerModel.flag = answ.flag;

                    qqa.answers.Add(answerModel);
                    

                }
               
                qqa.Questions.Add(questionModel);
                
            }

           
            return View(qqa);
        }

        // POST: QuestionAnswers/Create
        [HttpPost]
        public ActionResult loadQuiz(QuizQuestionAnswers qqa)
        {
            try
            {
               
                //TempData["score"] = 0;
                //TempData["score_quest"] = 0;
                if (qqa != null)
                {
                    quiz quiz = qz.GetById((int)qqa.quizId);
                    var id = quiz.id_Quiz;
                    var questions = qqa.Questions;
                    var answers = qqa.answers;
                    List<float> scores = new List<float>();
                    List<float> score_quests = new List<float>();
                    //  quiz.Result = 0;


                    foreach (var quest in questions)
                    {
                        
                        var qId = quest.id_Question;
                        question q = new question();
                        q = qts.GetById(qId);
                        q.userchoice = quest.userchoice;
                        qts.Commit();
                        //quest.userchoice= questions.Find(x=>x.id_Question==qId).userchoice;

                      // foreach (var answ in answers)
                        //{
                            //answer s = new answer();
                            //s = ans.GetById(answ.id_Answer);
                           // s.id_Answer = answ.id_Answer;
                          //  s.flag = answ.flag;
                          //  s.question_id_Question = answ.question_id_Question;
                            
                            if (q.userchoice.Equals(true))
                            {

                                score += 100 / questions.Count();
                            }
                        score = score+0;                                                                    
                       // }
                       // score_quests.Add(scores.Sum());
                        //TempData["score_quest"] = Convert.ToInt32(TempData["score"]) + Convert.ToInt32(TempData["score_quest"]);

                    }

                    qqa.score =(int) score;
                       
                  
                    // quiz.Result+= Convert.ToInt32(TempData["score_quest"]);
                    quiz.Result = qqa.score;
                    qz.Commit();
                    
                    SendEmail(quiz.Result);
                    // qz.Update(quiz);



                    return RedirectToAction("Details", new { id = qqa.quizId, otherParam = score_quests.Sum() });
                    //   return RedirectToAction("Index");
                    // return View(quiz);
                }
                else
                {
                    return new HttpNotFoundResult();

                }
            }
            
            catch
            {
                return View();
            }
        }



        [HttpPost]
        public ActionResult SendEmail(int? result)
        {
            try
            {
                var fromAddress = new MailAddress("iness.zaier@gmail.com", "Advyteam certifications");
                var toAddress = new MailAddress("ines.zaier@esprit.tn");
                const string fromPassword = "5otbtyflsif!<3";
                string subject = "Certification "; //your subject line
                string body = "Your certification score is : "+ result.ToString() ;// your body
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com", //example
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                    Timeout = 20000
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body

                })
                {
                    try
                    {
                        smtp.EnableSsl = true;
                        smtp.Send(message);
                        Debug.WriteLine("mail Send");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("*****************************" + ex.ToString());
                    }

                }
            
                    return View();
                
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }
            return View();
        }



        // GET: QuestionAnswers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: QuestionAnswers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: QuestionAnswers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: QuestionAnswers/Delete/5
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
        }
    }
}
