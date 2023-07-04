using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AngularBigBang.Models;

public partial class AngularBigBangContext : DbContext
{
    public AngularBigBangContext()
    {
    }

    public AngularBigBangContext(DbContextOptions<AngularBigBangContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<TimeSlot> TimeSlots { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source = .\\SQLEXPRESS; initial catalog = AngularBigBang; integrated security=SSPI;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Booking__3214EC0726143C2B");

            entity.ToTable("Booking");

            entity.Property(e => e.Date).HasColumnType("date");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("FK__Booking__DoctorI__72C60C4A");

            entity.HasOne(d => d.Time).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.TimeId)
                .HasConstraintName("FK__Booking__TimeId__73BA3083");

            entity.HasOne(d => d.User).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Booking__UserId__71D1E811");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Doctor__3214EC07FD6B23E4");

            entity.ToTable("Doctor");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Specialization)
                .HasMaxLength(100)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .HasDefaultValueSql("('')")
                .HasColumnName("userName");
        });

        modelBuilder.Entity<TimeSlot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TimeSlot__3214EC07CDCAF523");

            entity.ToTable("TimeSlot");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Gender).HasDefaultValueSql("('')");
            entity.Property(e => e.Name).HasDefaultValueSql("('')");
            entity.Property(e => e.Role).HasDefaultValueSql("('')");
            entity.Property(e => e.UserName)
                .HasDefaultValueSql("('')")
                .HasColumnName("userName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
