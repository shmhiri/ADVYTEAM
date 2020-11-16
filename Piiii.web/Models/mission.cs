using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace Piiii.web.Models
{
  
    public class mission
    {


        [Key]
        public int refrence { get; set; }








       
        public DateTime date { get; set; }
        [Required]
        public DateTime datedebut { get; set; }

        [Required]
        public DateTime datefin { get; set; }

        [Required]
        public string description { get; set; }

        [Required]
        public string estimation { get; set; }

        
        public string etat { get; set; }

        
        public bool? isProvidedAccd { get; set; }

      
        public bool? isProvidedTrsp { get; set; }

        public int participantsNumber { get; set; }

        [Required]
        public string place { get; set; }

   

       
        public string secondSkill { get; set; }

        [Required]
        public string skillsRequired { get; set; }

       
        public string state { get; set; }

        [Required]
        public string subject { get; set; }

       
        public string thirdSkill { get; set; }

  

    }
}