namespace Piiii.domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.missionexpenses")]
    public partial class missionexpenses
    {
        [Key]
        public int refrence { get; set; }

        public int? isApproved { get; set; }

        public double totalRecovered { get; set; }

        public int? mission_refrence { get; set; }

        public double cost { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime? date { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(255)]
        public string image { get; set; }

        public double kilomtrage { get; set; }

        public double totalCost { get; set; }

        [StringLength(255)]
        public string type { get; set; }

        public int? user_userId { get; set; }

        public virtual mission mission { get; set; }

        public virtual user user { get; set; }
    }
}
