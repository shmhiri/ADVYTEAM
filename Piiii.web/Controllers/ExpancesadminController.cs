
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
using System.Configuration;
using Stripe;


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

       /* public ActionResult Charge(string stripeEmail, string stripeToken)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = "sk_test_fvhJDcBr4JfTrSwJu9MCAeIm00L70wipbW"
            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = 500,
                Description = "Sample Charge",
                Currency = "usd",
                Customer = customer.Id
            });

            return View();
        }

    */


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
