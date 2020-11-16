using System;
using System.ComponentModel.DataAnnotations;

namespace Piiii.web.Models
{
    public class DemandViewModel
    {


        public int Id_conge { get; set; }

        public DateTime? date_debut { get; set; }

        public DateTime? date_fin { get; set; }

       
        public string etat { get; set; }

      
        public string raison { get; set; }

        public int? user_userId { get; set; }

        public virtual user user { get; set; }

    }
}