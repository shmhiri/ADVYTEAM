namespace Piiii.domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.answer")]
    public partial class answer
    {
        [Key]
        public int id_Answer { get; set; }

        [StringLength(255)]
        public string answer_name { get; set; }

        public int? question_id_Question { get; set; }

        [Column(TypeName = "bit")]
        public bool? flag { get; set; }

        public virtual question question { get; set; }
    }
}
