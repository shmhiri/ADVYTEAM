
using Piiii.domain;
using Piiii.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net;
using System.Net.Mail;
using Rotativa;
using Rotativa.Options;


namespace Piiii.web.Controllers
{
    public class ExpancesadminController : Controller
    {
       // private Context context = new Context();
        public ExpancesService ExpS { get; set; }

      
        public ExpancesadminController()
        {
            ExpS = new ExpancesService();
          
        }
        // GET: Expances
        [HttpGet]
        public ActionResult Index(string filtre, string lama)
        {
          //  int sid = (int)Session["userId"];
          //  System.Diagnostics.Debug.WriteLine("response :" + sid);

            // HttpContext context = HttpContext.Session;
            //String userId = HttpContext.Current.Session["UserID"];
            // int sid = (int)Session["userId"];
            // var posts = ExpS.GetexpanssessByuser(sid);
            var posts = ExpS.GetMany();
            if (!String.IsNullOrEmpty(filtre))
            { posts = posts.Where(m => m.description.ToString().Contains(filtre) || m.cost.ToString().Contains(filtre) ||  m.kilomtrage.ToString().Contains(filtre)).ToList(); }
            if (!String.IsNullOrEmpty(lama))
            {
                posts = posts.Where(m => m.type.ToString().Contains(lama)).ToList();
            }
                return View(posts);
          
        }
        public static SmtpClient getSMTPClient()
        {
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.UseDefaultCredentials = true;
            client.Credentials = new NetworkCredential("sunflower.thesquad@gmail.com", "wa7edthnen");
            client.EnableSsl = true;
    
            return client;
        }
        public static void SendConfirmationMail(int id)
        {
            MailMessage message = new MailMessage();

            message.To.Add(new MailAddress("shmhiri@gmail.com"));
            message.From =new MailAddress("sunflower.thesquad@gmail.com");
            // var mail = new MailMessage(receiver, sender);
           // message.Subject = "Subject";
           // message.Body = "Body";
          
            SmtpClient smtp = getSMTPClient();

            message.IsBodyHtml = true;
            message.Subject = "detail";
            message.Body =
                  "<em><a href=\"http://localhost:52613/Mission/missionExpnce/" + id + "\">cliquez ici pour plus de detail votre compte</a></em>";

           // SmtpServer.Send(mail);
            // smtp.Credentials = new NetworkCredential("sunflower.thesquad@gmail.com", "wa7edthnen");
            // smtp.Host = "smtp.gmail.com";
            // smtp.Port = 587; //Should be working


            //  smtp.EnableSsl = true;
            smtp.Send(message);


           
          //  message.From = new MailAddress("userid@yahoo.com");
           // message.To.Add(new MailAddress("ngqandu.anele@gmail.com"));
          //  message.Subject = subject.Text;
//message.Body = body.Text;

         //   SmtpClient client = new SmtpClient();
        //    client.Credentials = new System.Net.NetworkCredential("userid@yahoo.com", "password");

       //     client.Port = 587;
          //  client.Host = "smtp.mail.yahoo.com";
          //  client.EnableSsl = false;
                }

        // GET: Expances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            missionexpenses missionexpenses = ExpS.GetById((int)id);
            if (missionexpenses == null)
            {
                return HttpNotFound();
            }

            SendConfirmationMail((int)id);

            return View(missionexpenses);

           
        }

        public ActionResult mail(int? id)
        {
         

            SendConfirmationMail((int)id);

            return View();


        }




        // GET: Expances/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Expances/Create
        [HttpPost]
        public ActionResult Create(missionexpenses post, HttpPostedFileBase file,int? id)
        {
           

            if (file != null)
            {
                string fileName = Path.GetFileName(file.FileName);
                string path = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                file.SaveAs(path);
            }
            if (post.kilomtrage ==null)
            {
                post.kilomtrage = 0;
            }
            int sid =(int) Session["userId"];
           System.Diagnostics.Debug.WriteLine("response :" + sid);
            post.user_userId = sid;
           // post.isApproved = 0;
            post.mission_refrence = id;
            post.image = file.FileName;
            post.date = System.DateTime.Now;
            // SendConfirmationMail(post.refrence);
            //context.missionexpenses.Add(post);
            //context.SaveChanges();
            
          
            ExpS.Add(post);
            ExpS.Commit();

      
            return RedirectToAction("Index");
         
           
        }

        // GET: Expances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            missionexpenses missionexpenses = ExpS.GetById((int)id);
            if (missionexpenses == null)
            {
                return HttpNotFound();
            }
            return View(missionexpenses);
        }

        // POST: Expances/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( int? id,HttpPostedFileBase file, missionexpenses missionex)
        {
            missionexpenses missionexpenses = ExpS.GetById((int)id);

            if (file != null)
            {
                string fileName = Path.GetFileName(file.FileName);
                string path = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                file.SaveAs(path);
            }
            if (missionex.kilomtrage == null)
            {
                missionexpenses.kilomtrage = 0;
            }
            missionexpenses.cost = missionex.cost;
            missionexpenses.description = missionex.description;
            missionexpenses.kilomtrage = missionex.kilomtrage;
            missionexpenses.type = missionex.type;
            missionexpenses.image = file.FileName;
            missionexpenses.date = System.DateTime.Now;


            //context.missionexpenses.Add(post);
            //context.SaveChanges();
           

            ExpS.Update(missionexpenses);
            ExpS.Commit();


            return RedirectToAction("Index");
        }

        // GET: Expances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            missionexpenses missionexpenses = ExpS.GetById((int)id);
            if (missionexpenses == null)
            {
                return HttpNotFound();
            }
            return View(missionexpenses);
        }

        // POST: Expances/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            missionexpenses p = ExpS.GetById(id);
            ExpS.Delete(p);
            ExpS.Commit();
            //postService.Dispose();
            return RedirectToAction("Index");
        }


        public ActionResult PrintPDF()
        {
            var posts = ExpS.GetMany();
           // posts.ToList();

            List<missionexpenses> Data = posts.ToList();

            return new PartialViewAsPdf("PrintPDF", Data)
            {
                   PageOrientation = Orientation.Landscape,  
               PageSize = Size.A3,  
               CustomSwitches = "--footer-center \" [page] Page of [toPage] Pages\" --footer-line --footer-font-size \"9\" --footer-spacing 5 --footer-font-name \"calibri light\"",  
               FileName = "TestPartialViewAsPdf.pdf"
            };
        }

        public ActionResult Like(int? id)
        {
            missionexpenses missionexpenses = ExpS.GetById((int)id);
            //  missionexpenses update = db.missionexpenses.ToList().Find(u => u.refrence == id);


            missionexpenses.isApproved += 1;
            //db.SaveChanges();
            ExpS.Update(missionexpenses);
            ExpS.Commit();
            return RedirectToAction("Index");
            
        }
    
        public ActionResult Dislike(int? id)
        {
            missionexpenses missionexpenses = ExpS.GetById((int)id);
          //  missionexpenses update = db.missionexpenses.ToList().Find(u => u.refrence == id);
            if(missionexpenses.isApproved == 0)
            {
                missionexpenses.isApproved += 1;
                ExpS.Update(missionexpenses);
                ExpS.Commit();
            }
            else
            {
                missionexpenses.isApproved -= 1;
                ExpS.Update(missionexpenses);
                ExpS.Commit();
            }
            return RedirectToAction("Index");
        }

    }
}
