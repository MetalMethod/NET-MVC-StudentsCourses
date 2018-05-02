namespace StudentCoursesMVC.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Registrations
    {
        public int ID { get; set; }

        public int Student_ID { get; set; }

        public int Course_ID { get; set; }

        [Required]
        [StringLength(255)]
        public string RegistrationKey { get; set; }

        public virtual Courses Courses { get; set; }

        public virtual Students Students { get; set; }
    }
}
