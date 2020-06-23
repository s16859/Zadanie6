using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Zadanie6.Models
{
    public class StudiesContext : DbContext
    {
        public DbSet<Student> students { get; set; }
        public DbSet<Studies> studies { get; set; }
        public DbSet<Enrollment> enrollments { get; set; }


        public StudiesContext(DbContextOptions options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Student>()
                .HasOne<Enrollment>(z => z.enrollment)
                .WithMany(k => k.students)
                .HasForeignKey(zi => zi.IdEnrollment);

            modelBuilder.Entity<Enrollment>()
                .HasOne<Studies>(z => z.studies)
                .WithMany(p => p.enrollments)
                .HasForeignKey(zi => zi.IdStudy);

            modelBuilder.Entity<Student>().HasData(

            new Student
            {
                IndexNumber = "s16859",
                FirstName = "Przemyslaw",
                LastName = "Szczerba",
                BirthDate = new DateTime(1995, 01, 28),
                IdEnrollment = 1

            }
            );

            modelBuilder.Entity<Enrollment>().HasData(

            new Enrollment
            {
                IdEnrollment = 1,
                Semester = 1,
                StartDate = DateTime.Now,
                IdStudy=1

            }
            );

            modelBuilder.Entity<Studies>().HasData(

            new Studies
            {
                IdStudy=1,
                Name="Jakies"
            }
            );
        }
    }
}
