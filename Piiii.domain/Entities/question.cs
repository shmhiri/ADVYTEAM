namespace Piiii.domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.question")]
    public partial class question
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public question()
        {
            answer = new HashSet<answer>();
        }

        [Key]
        public int id_Question { get; set; }

        [StringLength(255)]
        public string question_name { get; set; }

        [Required]
        [StringLength(255)]
        public string question_description { get; set; }

        public int? quiz_id_Quiz { get; set; }

        [Column(TypeName = "bit")]
        public bool? userchoice { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<answer> answer { get; set; }

        public virtual quiz quiz { get; set; }
    }
}
