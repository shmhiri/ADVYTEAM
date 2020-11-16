namespace Piiii.web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public  partial class selfevaluationModel
    {
        [Key]
        public int id { get; set; }


        public string improvements { get; set; }

        public string qualities { get; set; }

        public int score { get; set; }

        public int Employee_id { get; set; }

        [ForeignKey("Employee_id")]
        public virtual employeeModel employee { get; set; }
    }
}
