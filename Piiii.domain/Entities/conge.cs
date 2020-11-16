namespace Piiii.domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.conge")]
    public partial class conge
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_conge { get; set; }

        public DateTime? date_debut { get; set; }

        public DateTime? date_fin { get; set; }

        [StringLength(255)]
        public string etat_demande { get; set; }

        [StringLength(255)]
        public string raison { get; set; }

        public int? employe_Id_emp { get; set; }

        public virtual employe employe { get; set; }
    }
}
