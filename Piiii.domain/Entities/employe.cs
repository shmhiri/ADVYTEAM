namespace Piiii.domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.employe")]
    public partial class employe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public employe()
        {
            conge = new HashSet<conge>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_emp { get; set; }

        [StringLength(255)]
        public string codePostal { get; set; }

        [StringLength(255)]
        public string pays { get; set; }

        [StringLength(255)]
        public string rue { get; set; }

        [StringLength(255)]
        public string ville { get; set; }

        public int cin { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [StringLength(255)]
        public string nom { get; set; }

        [StringLength(255)]
        public string poste { get; set; }

        [StringLength(255)]
        public string prenom { get; set; }

        [StringLength(255)]
        public string salaire { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<conge> conge { get; set; }
    }
}
