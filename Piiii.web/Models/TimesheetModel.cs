using Piiii.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Piiii.web.Models
{
    public class TimesheetModel
    {
        public TimesheetModel()
        {
            timesheet_activity = new HashSet<timesheet>();
        }

        public int id { get; set; }

        public int conges { get; set; }

        public int heure { get; set; }

        public int jour { get; set; }

        public string poste { get; set; }

        public int? employer_id_userId { get; set; }

        public virtual ICollection<timesheet> timesheet_activity { get; set; }
    }
}