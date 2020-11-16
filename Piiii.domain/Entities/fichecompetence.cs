namespace Piiii.domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.fichecompetence")]
    public partial class fichecompetence
    {
        [Key]
        public int id_fiche { get; set; }

        public int? NoteConception { get; set; }

        public int? NoteDevLogiciel { get; set; }

        public int? NoteGestionProjet { get; set; }

        public int? NoteMethodesAgile { get; set; }

        public int? NoteReporting { get; set; }

        [StringLength(255)]
        public string maitrise { get; set; }

        public int? user_id { get; set; }

        public int? user_Id_emp { get; set; }
    }
}
