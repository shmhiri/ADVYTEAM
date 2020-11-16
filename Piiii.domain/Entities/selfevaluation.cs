namespace Piiii.domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.selfevaluation")]
    public partial class selfevaluation
    {
        public int id { get; set; }

        [StringLength(255)]
        public string improvements { get; set; }

        [StringLength(255)]
        public string qualities { get; set; }

        public int? score { get; set; }

        public int? Employee_id { get; set; }

        public virtual employee employee { get; set; }
    }
}
