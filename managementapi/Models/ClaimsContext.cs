using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace managementapi.Models
{
    public partial class ClaimsContext : DbContext
    {
        public ClaimsContext()
        {
        }

        public ClaimsContext(DbContextOptions<ClaimsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Broker> Brokers { get; set; } = null!;
        public virtual DbSet<Create> Creates { get; set; } = null!;
        public virtual DbSet<Insurer> Insurers { get; set; } = null!;
        public virtual DbSet<LoginT> LoginTs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=PSL-5CD201FG4T\\SQLEXPRESS; Database=Claims; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Broker>(entity =>
            {
                entity.ToTable("Broker");

                entity.Property(e => e.BrokerId)
                    .ValueGeneratedNever()
                    .HasColumnName("BrokerID");

                entity.Property(e => e.BrokerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Create>(entity =>
            {
                entity.ToTable("Create");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BrokerId).HasColumnName("BrokerID");

                entity.Property(e => e.BrokerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClaimTypeCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CloseDate).HasColumnType("date");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.InsuredClaimNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InsuredContactedDate).HasColumnType("date");

                entity.Property(e => e.InsuredFirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InsuredName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InsurerId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("InsurerID");

                entity.Property(e => e.LastChanged)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastChangedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LossDate).HasColumnType("date");

                entity.Property(e => e.LossDescCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LossLocation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OpenDate).HasColumnType("date");

                entity.Property(e => e.OrganizationCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PolicyExpiryDate).HasColumnType("date");

                entity.Property(e => e.PolicyInceptionDate).HasColumnType("date");

                entity.Property(e => e.PolicyNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiveDate).HasColumnType("date");
            });

            modelBuilder.Entity<Insurer>(entity =>
            {
                entity.ToTable("Insurer");

                entity.Property(e => e.InsurerId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("InsurerID");

                entity.Property(e => e.OrganizationCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PolicyNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LoginT>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.ToTable("LoginT");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
