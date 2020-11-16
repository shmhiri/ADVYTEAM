using Piiii.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Piiii.web.Models
{
    public class Project_ActivityModel
    {
        public int Project_id { get; set; }
        public int activity_id { get; set; }
        public virtual project project { get; set; }

    }
}