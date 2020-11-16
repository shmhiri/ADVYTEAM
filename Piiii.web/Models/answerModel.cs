using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Piiii.web.Models
{
    public class answerModel
    {
        [Key]
        public int id_Answer { get; set; }

        [StringLength(255)]
        public string answer_name { get; set; }

        public int? question_id_Question { get; set; }

        [Column(TypeName = "bit")]
        public bool? flag { get; set; }

        public virtual questionModel question { get; set; }
    }
}