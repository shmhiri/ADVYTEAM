namespace Piiii.domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.mission")]
    public partial class mission
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public mission()
        {
            expensenote = new HashSet<expensenote>();
            missionexpenses = new HashSet<missionexpenses>();
        }

        [Key]
        public int refrence { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? datedebut { get; set; }

        [Column(TypeName = "date")]
        public DateTime? datefin { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(255)]
        public string estimation { get; set; }

        public int? etat { get; set; }

        [Column(TypeName = "bit")]
        public bool? isProvidedAccd { get; set; }

        [Column(TypeName = "bit")]
        public bool? isProvidedTrsp { get; set; }

        public int participantsNumber { get; set; }

        [StringLength(255)]
        public string place { get; set; }

        [Column(TypeName = "bit")]
        public bool? pressed { get; set; }

        [StringLength(255)]
        public string secondSkill { get; set; }

        [StringLength(255)]
        public string skillsRequired { get; set; }

        [StringLength(255)]
        public string state { get; set; }

        [StringLength(255)]
        public string subject { get; set; }

        [StringLength(255)]
        public string thirdSkill { get; set; }

        [Column(TypeName = "bit")]
        public bool? notpressed { get; set; }

        public int? user_userId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<expensenote> expensenote { get; set; }

        public virtual user user { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<missionexpenses> missionexpenses { get; set; }
    }
}
