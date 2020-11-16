using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Piiii.web.Models
{
    public class ActivityModel
    {
        public int id { get; set; }
        public string code { get; set; }
        public DateTime? datedebut { get; set; }
        public DateTime? datefin { get; set; }
        public DateTime? datesubmited { get; set; }
        public string etat { get; set; }
        public string otherdetai { get; set; }
        public int? emploey_id_userId { get; set; }

        public int? project_id_id { get; set; }

        public int? timesheetid_id { get; set; }
    }
}