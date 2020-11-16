using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Piiii.web.Models
{
    public class EmployeViewModels
    {
        public int userId { get; set; }
        public DateTime? dateNaissance { get; set; }
        public string email { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string poste { get; set; }
        public string salaire { get; set; }
        public string adresse { get; set; }

        public string image { get; set; }


    }
}