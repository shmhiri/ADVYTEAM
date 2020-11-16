namespace Piiii.domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.evaluation360")]
    public partial class evaluation360
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public evaluation360()
        {
            evaluation360done = new HashSet<evaluation360done>();
        }

        public int id { get; set; }

        [Column(TypeName = "bit")]
        public bool? done { get; set; }

        public int? score { get; set; }

        public int? Employee_id { get; set; }

        public virtual employee employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<evaluation360done> evaluation360done { get; set; }
    }
}
