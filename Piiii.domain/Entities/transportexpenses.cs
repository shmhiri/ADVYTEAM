namespace Piiii.domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.transportexpenses")]
    public partial class transportexpenses
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public transportexpenses()
        {
            expensenote = new HashSet<expensenote>();
        }

        public int id { get; set; }

        [StringLength(255)]
        public string boardingTicket { get; set; }

        public double costs { get; set; }

        public double kms { get; set; }

        [StringLength(255)]
        public string trspType { get; set; }

        public double visa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<expensenote> expensenote { get; set; }
    }
}
