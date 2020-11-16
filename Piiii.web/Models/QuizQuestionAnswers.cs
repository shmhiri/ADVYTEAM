using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Piiii.web.Models
{
    public class QuizQuestionAnswers

    {
        public int? quizId { get; set; }

        public List<questionModel> Questions { get; set; } 

        public  List<answerModel> answers { get; set; } 

        public int? score { get; set; }

        public QuizQuestionAnswers()
        {
            this.Questions = new List<questionModel>();

        this.answers = new List<answerModel>();
    }
        
        

}
}