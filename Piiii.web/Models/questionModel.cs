using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Piiii.web.Models
{
    public class questionModel
    {
        [Key]
         public int id_Question { get; set; }

        [StringLength(255)]
        public string question_name { get; set; }

        [StringLength(255)]
        public string question_description { get; set; }

        public bool? userchoice { get; set; }

        public int? quiz_id_Quiz { get; set; }

        public virtual ICollection<answerModel> answer { get; set; }

        public virtual quizModel quiz { get; set; }
    }
}