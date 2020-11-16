using Piiii.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Piiii.data;
using Piiii.domain;

namespace Piiii.web.Controllers
{
    public class ProjectController : Controller
    {
        private Context db = new Context();
        // GET: Project
        public ActionResult Index()
        {

            var project = db.project;

            return View(project.ToList());
        }
        // GET: Project/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reservation/Create
        [HttpPost]
        public ActionResult Create(project project)
        {    
            
                return View();
           
        }

        
    }
}