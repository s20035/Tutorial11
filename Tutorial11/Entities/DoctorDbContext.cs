using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorial11.Entities
{
    public class DoctorDbContext : DbContext 
    {
        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Prescription> Prescriptions { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Medicament> Medicaments { get; set;}

        public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }
        public DoctorDbContext() { }

        public DoctorDbContext(DbContextOptions options):base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.IdDoctor);
                entity.Property(e => e.IdDoctor).ValueGeneratedOnAdd();
                entity.Property(e => e.FirstName).IsRequired();

                entity.ToTable("Doctor");

                entity.HasMany(d => d.Prescriptions)
                       .WithOne(p => p.Doctor)
                       .HasForeignKey(p => p.IdDoctor)
                       .IsRequired();



            }
            );
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.IdPatient);
                entity.Property(e => e.IdPatient).ValueGeneratedOnAdd();
                entity.Property(e => e.Firstname).IsRequired();

                entity.ToTable("Patient");

                entity.HasMany(d => d.Prescriptions)
                       .WithOne(p => p.Patient)
                       .HasForeignKey(p => p.IdPatient)
                       .IsRequired();
            }
            );

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasKey(e => e.IdPrescritption);
                entity.Property(e => e.IdPrescritption).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Prescription_Medicament)
                       .WithOne(p => p.Prescription);
                      

                entity.ToTable("Prescription");

            }
            );

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(e => e.IdMedicament);
                entity.Property(e => e.IdMedicament).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Prescription_Medicament)
                      .WithOne(p => p.Medicament); 


                entity.ToTable("Medicament");
            }
            );

            modelBuilder.Entity<Prescription_Medicament>(entity =>
            {
                entity.HasKey(e => new { e.IdPrescription, e.IdMedicament });
                entity.Property(e => e.Dose).IsRequired();
                


                entity.ToTable("Prescription-Medicament");
            }
            );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { IdDoctor = 245, FirstName = "Simphiwe", LastName = "Dlamini", EMail = "Iamhere@yahoo.con" },
                new Doctor { IdDoctor =268 , FirstName = "Ntokozo" , LastName = "Ndabandaba", EMail ="Kingof@Earth.coz" },
                new Doctor { IdDoctor = 472 ,FirstName = "Nosimilo", LastName = "Ntshangase",EMail = "Lifeis@LG.faz" }
                );
        }
    }
}
