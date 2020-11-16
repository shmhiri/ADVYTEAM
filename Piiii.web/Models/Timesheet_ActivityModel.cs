using Piiii.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Piiii.web.Models
{
    public class Timesheet_ActivityModel
    {
        public int Timesheet_id { get; set; }


        public int activity_id { get; set; }

        public virtual timesheet timesheet { get; set; }
    }
}