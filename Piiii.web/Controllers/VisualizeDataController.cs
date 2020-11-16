using Piiii.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Piiii.data;
using Piiii.web.Models;

namespace Piiii.web.Controllers
{
    public class VisualizeDataController : Controller
    {
        private Context db = new Context();

        public ActionResult ColumnChart()
        {
            return View();
        }

        public ActionResult PieChart()
        {
            return View();
        }

        public ActionResult LineChart()
        {
            return View();
        }

        public ActionResult VisualizeStudentResult()
        {
            return Json(Result(), JsonRequestBehavior.AllowGet);
        }

        public List<StatResult> Result()
        {     
            var timesheet = db.timesheet.ToList();
            List<StatResult> stdResult = new List<StatResult>();

            stdResult.Add(new StatResult() {
                stdName = "Ahmed",
                marksObtained = 88

            });
            stdResult.Add(new StatResult()
            {
                stdName = "Houssem",
                marksObtained = 50

            });
            stdResult.Add(new StatResult()
            {
                stdName = "Ali",
                marksObtained = 120

            }); stdResult.Add(new StatResult()
            {
                stdName = "Hassen",
                marksObtained = 80

            });
            return stdResult;
        }
    }
}