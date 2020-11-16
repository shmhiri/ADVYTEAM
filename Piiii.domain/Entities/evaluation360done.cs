namespace Piiii.domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.evaluation360done")]
    public partial class evaluation360done
    {
        public int id { get; set; }

        [StringLength(255)]
        public string improvements { get; set; }

        [StringLength(255)]
        public string qualities { get; set; }

        [StringLength(255)]
        public string score { get; set; }

        public int? Coworker_id { get; set; }

        public int? Evaluation360_id { get; set; }

        public virtual employee employee { get; set; }

        public virtual evaluation360 evaluation360 { get; set; }
    }
}
