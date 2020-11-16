using System;
using Piiii.domain;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Piiii.web.Models
{
    public class ProjectModel
    {
        public ProjectModel()
        {
            project1 = new HashSet<project>();
            project_activity = new HashSet<project>();
        }

        public int id { get; set; }

        public string Name { get; set; }

        public DateTime? datedebut { get; set; }

        public DateTime? datefin { get; set; }

        public string otherdetai { get; set; }

        public int? Project_code_id { get; set; }

        public int? manager_id_userId { get; set; }
        public virtual ICollection<project> project1 { get; set; }

        public virtual project project2 { get; set; }
        public virtual ICollection<project> project_activity { get; set; }

    }
}