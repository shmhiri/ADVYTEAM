using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Piiii.web.Models
{
    public class catalogModel
    {
        [Key]
        public int id_cat { get; set; }

        [StringLength(255)]
        public string nom_cat { get; set; }

        public virtual ICollection<formationModel> formation { get; set; }
    }
}