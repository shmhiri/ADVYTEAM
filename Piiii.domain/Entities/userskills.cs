namespace Piiii.domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.userskills")]
    public partial class userskills
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int userId { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [StringLength(255)]
        public string image { get; set; }

        [StringLength(255)]
        public string nom { get; set; }

        [StringLength(255)]
        public string password { get; set; }

        [StringLength(255)]
        public string prenom { get; set; }

        [StringLength(255)]
        public string role { get; set; }

        [StringLength(255)]
        public string secondSkill { get; set; }

        [StringLength(255)]
        public string skillsRequired { get; set; }

        [StringLength(255)]
        public string thirdSkill { get; set; }
    }
}
