using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DBMS.Models;

public partial class NeondbContext : DbContext
{
    public NeondbContext()
    {
    }

    public NeondbContext(DbContextOptions<NeondbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Disease> Diseases { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<PatientDisease> PatientDiseases { get; set; }

    public virtual DbSet<PatientDoctor> PatientDoctors { get; set; }

//     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//         => optionsBuilder.UseNpgsql("Host=ep-lively-tree-a4rbt7gw-pooler.us-east-1.aws.neon.tech;Database=neondb;Username=neondb_owner;Password=npg_Mz3nZtuv1VDw");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Disease>(entity =>
        {
            entity.HasKey(e => e.Diseaseid).HasName("disease_pkey");

            entity.ToTable("disease");

            entity.Property(e => e.Diseaseid)
                .ValueGeneratedNever()
                .HasColumnName("diseaseid");
            entity.Property(e => e.Diseasename)
                .HasMaxLength(50)
                .HasColumnName("diseasename");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.Doctorid).HasName("doctor_pkey");

            entity.ToTable("doctor");

            entity.Property(e => e.Doctorid)
                .ValueGeneratedNever()
                .HasColumnName("doctorid");
            entity.Property(e => e.Doctorname)
                .HasMaxLength(50)
                .HasColumnName("doctorname");
            entity.Property(e => e.Speciality)
                .HasMaxLength(50)
                .HasColumnName("speciality");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Patientid).HasName("patient_pkey");

            entity.ToTable("patient");

            entity.Property(e => e.Patientid)
                .ValueGeneratedNever()
                .HasColumnName("patientid");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<PatientDisease>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("patient_disease");

            entity.Property(e => e.Diseaseid).HasColumnName("diseaseid");
            entity.Property(e => e.Patientid).HasColumnName("patientid");

            entity.HasOne(d => d.Disease).WithMany()
                .HasForeignKey(d => d.Diseaseid)
                .HasConstraintName("patient_disease_diseaseid_fkey");

            entity.HasOne(d => d.Patient).WithMany()
                .HasForeignKey(d => d.Patientid)
                .HasConstraintName("patient_disease_patientid_fkey");
        });

        modelBuilder.Entity<PatientDoctor>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("patient_doctor");

            entity.Property(e => e.Doctorid).HasColumnName("doctorid");
            entity.Property(e => e.Patientid).HasColumnName("patientid");

            entity.HasOne(d => d.Doctor).WithMany()
                .HasForeignKey(d => d.Doctorid)
                .HasConstraintName("patient_doctor_doctorid_fkey");

            entity.HasOne(d => d.Patient).WithMany()
                .HasForeignKey(d => d.Patientid)
                .HasConstraintName("patient_doctor_patientid_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
