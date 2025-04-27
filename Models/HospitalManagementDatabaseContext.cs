using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyMvcApp.Models;

public partial class HospitalManagementDatabaseContext : DbContext
{
    public HospitalManagementDatabaseContext()
    {
    }

    public HospitalManagementDatabaseContext(DbContextOptions<HospitalManagementDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Billing> Billings { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Medicalrecord> Medicalrecords { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

   // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
  //      => optionsBuilder.UseNpgsql("Host=ep-orange-silence-a462rh5t-pooler.us-east-1.aws.neon.tech;Database=Hospital-Management-Database;Username=Hospital-Management-Database_owner;Password=npg_yJCFvgI7x3cR");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("appointments_pkey");

            entity.ToTable("appointments");

            entity.Property(e => e.AppointmentId)
                .ValueGeneratedNever()
                .HasColumnName("appointment_id");
            entity.Property(e => e.AppointmentDate).HasColumnName("appointment_date");
            entity.Property(e => e.DoctorId).HasColumnName("doctor_id");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
        });

        modelBuilder.Entity<Billing>(entity =>
        {
            entity.HasKey(e => e.BillId).HasName("billing_pkey");

            entity.ToTable("billing");

            entity.Property(e => e.BillId)
                .ValueGeneratedNever()
                .HasColumnName("bill_id");
            entity.Property(e => e.Amount)
                .HasPrecision(10, 2)
                .HasColumnName("amount");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(50)
                .HasColumnName("payment_status");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.DoctorId).HasName("doctors_pkey");

            entity.ToTable("doctors");

            entity.Property(e => e.DoctorId)
                .ValueGeneratedNever()
                .HasColumnName("doctor_id");
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(15)
                .HasColumnName("contact_number");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Specialization)
                .HasMaxLength(255)
                .HasColumnName("specialization");
        });

        modelBuilder.Entity<Medicalrecord>(entity =>
        {
            entity.HasKey(e => e.RecordId).HasName("medicalrecords_pkey");

            entity.ToTable("medicalrecords");

            entity.Property(e => e.RecordId)
                .ValueGeneratedNever()
                .HasColumnName("record_id");
            entity.Property(e => e.Diagnosis).HasColumnName("diagnosis");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.Prescription).HasColumnName("prescription");
            entity.Property(e => e.VisitDate).HasColumnName("visit_date");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("patients_pkey");

            entity.ToTable("patients");

            entity.Property(e => e.PatientId)
                .ValueGeneratedNever()
                .HasColumnName("patient_id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(15)
                .HasColumnName("contact_number");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .HasColumnName("gender");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("staff_pkey");

            entity.ToTable("staff");

            entity.Property(e => e.StaffId)
                .ValueGeneratedNever()
                .HasColumnName("staff_id");
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(15)
                .HasColumnName("contact_number");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Role)
                .HasMaxLength(255)
                .HasColumnName("role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
