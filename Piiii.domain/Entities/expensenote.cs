namespace Piiii.domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.expensenote")]
    public partial class expensenote
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public expensenote()
        {
            accommodationexpenses = new HashSet<accommodationexpenses>();
            transportexpenses = new HashSet<transportexpenses>();
        }

        [Key]
        public int refrence { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        [Column(TypeName = "bit")]
        public bool? isApproved { get; set; }

        public double totalCost { get; set; }

        public double totalRecovered { get; set; }

        public int? employee_userId { get; set; }

        public int? mission_refrence { get; set; }

        public int? officer_userId { get; set; }

        public virtual mission mission { get; set; }

        public virtual user user { get; set; }

        public virtual user user1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<accommodationexpenses> accommodationexpenses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<transportexpenses> transportexpenses { get; set; }
    }
}
