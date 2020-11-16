using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Piiii.web.Models
{
    public class formationModel
    {
        [Key]
         public int id_for { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_debut { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        public int? duree { get; set; }

        [StringLength(255)]
        public string lieu { get; set; }

        [StringLength(255)]
        public string niveauobt { get; set; }

        [StringLength(255)]
        public string nom_anim { get; set; }

        [StringLength(255)]
        public string nom_for { get; set; }

        [StringLength(255)]
        public string prerequis { get; set; }

        public int? cat_id_cat { get; set; }

        public int? quiz_id_Quiz { get; set; }

        public virtual catalogModel catalog { get; set; }

        public virtual quizModel quiz { get; set; }

      
    }
}