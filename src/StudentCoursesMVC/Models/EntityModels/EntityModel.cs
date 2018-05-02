namespace StudentCoursesMVC.Models.EntityModels
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EntityModel : DbContext
    {
        public EntityModel()
            : base("name=EntityModel")
        {
        }

        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Registrations> Registrations { get; set; }
        public virtual DbSet<Students> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Courses>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Courses>()
                .HasMany(e => e.Registrations)
                .WithRequired(e => e.Courses)
                .HasForeignKey(e => e.Course_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Registrations>()
                .Property(e => e.RegistrationKey)
                .IsUnicode(false);

            modelBuilder.Entity<Students>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Students>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Students>()
                .HasMany(e => e.Registrations)
                .WithRequired(e => e.Students)
                .HasForeignKey(e => e.Student_ID)
                .WillCascadeOnDelete(false);
        }
    }
}
