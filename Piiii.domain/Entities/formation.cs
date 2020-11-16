namespace Piiii.domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.formation")]
    public partial class formation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public formation()
        {
            quiz1 = new HashSet<quiz>();
        }

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

        public virtual catalog catalog { get; set; }

        public virtual quiz quiz { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<quiz> quiz1 { get; set; }
    }
}
