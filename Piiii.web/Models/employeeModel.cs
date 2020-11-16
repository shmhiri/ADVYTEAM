namespace Piiii.web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public class employeeModel
    {
        
        [Key]
        public int id { get; set; }

        public string name { get; set; }

        public virtual ICollection<evaluation360Model> evaluation360 { get; set; }

        public employeeModel()
        {

        }
        public employeeModel(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        
    }
}
