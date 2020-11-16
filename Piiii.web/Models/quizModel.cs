
using Piiii.data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace Piiii.web.Models
{
    public class quizModel : IValidatableObject
    {
        [Key]

        public int id_Quiz { get; set; }

        [Required]
        [StringLength(255)]
        [Index( IsUnique = true)]
        public String QuizName { get; set; }

        public static int? Result { get; set; }
        [Required]
        public int? formation_id_for { get; set; }

       public virtual ICollection<formationModel> formation { get; set; }

        public virtual formationModel formation1 { get; set; }

       public virtual ICollection<questionModel> question { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            Context db = new Context();
            var validateName = db.quiz.FirstOrDefault
            (x => x.QuizName == QuizName && x.id_Quiz != id_Quiz);
            if (validateName != null)
            {
                ValidationResult errorMessage = new ValidationResult
                ("Quiz name already exists.", new[] { "QuizName" });
                yield return errorMessage;
            }
            else
            {
                yield return ValidationResult.Success;
            }
        }
    }
}