namespace Piiii.domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.activity")]
    public partial class activity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public activity()
        {
            project1 = new HashSet<project>();
            timesheet1 = new HashSet<timesheet>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(255)]
        public string code { get; set; }

        [Column(TypeName = "date")]
        public DateTime? datedebut { get; set; }

        public DateTime? datefin { get; set; }

        public DateTime? datesubmited { get; set; }

        [StringLength(255)]
        public string etat { get; set; }

        [StringLength(255)]
        public string otherdetai { get; set; }

        public int? emploey_id_userId { get; set; }

        public int? project_id_id { get; set; }

        public int? timesheetid_id { get; set; }

        public virtual timesheet timesheet { get; set; }

        public virtual user user { get; set; }

        public virtual project project { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<project> project1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<timesheet> timesheet1 { get; set; }
    }
}
