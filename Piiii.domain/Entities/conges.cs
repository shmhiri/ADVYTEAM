namespace Piiii.domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.conges")]
    public partial class conges
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(255)]
        public string comment { get; set; }

        public DateTime? date { get; set; }

        [StringLength(255)]
        public string etat { get; set; }

        public int nbr { get; set; }

        public int? employer_id_userId { get; set; }

        public int? timesheet_id { get; set; }

        public virtual user user { get; set; }

        public virtual timesheet timesheet { get; set; }
    }
}
