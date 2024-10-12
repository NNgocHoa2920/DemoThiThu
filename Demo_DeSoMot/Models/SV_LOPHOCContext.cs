using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Demo_DeSoMot.Models
{
    public partial class SV_LOPHOCContext : DbContext
    {
        public SV_LOPHOCContext()
        {
        }

        public SV_LOPHOCContext(DbContextOptions<SV_LOPHOCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Lophoc> Lophocs { get; set; } = null!;
        public virtual DbSet<Sinhvien> Sinhviens { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=NGUYEN_NGOC_HOA\\HOANN;Database=SV_LOPHOC;Trusted_Connection=True; TrustServerCertificate =True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lophoc>(entity =>
            {
                entity.HasKey(e => e.Malop)
                    .HasName("PK__LOPHOC__7A3DE21159C7DAE8");

                entity.ToTable("LOPHOC");

                entity.Property(e => e.Malop)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MALOP");

                entity.Property(e => e.Tenlop)
                    .HasMaxLength(50)
                    .HasColumnName("TENLOP");
            });

            modelBuilder.Entity<Sinhvien>(entity =>
            {
                entity.HasKey(e => e.Masv)
                    .HasName("PK__SINHVIEN__60228A28E7B8908D");

                entity.ToTable("SINHVIEN");

                entity.Property(e => e.Masv)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MASV");

                entity.Property(e => e.Malop)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MALOP");

                entity.Property(e => e.Nganh)
                    .HasMaxLength(50)
                    .HasColumnName("NGANH");

                entity.Property(e => e.Ngaysinh)
                    .HasColumnType("date")
                    .HasColumnName("NGAYSINH");

                entity.Property(e => e.Ten)
                    .HasMaxLength(50)
                    .HasColumnName("TEN");

                entity.HasOne(d => d.MalopNavigation)
                    .WithMany(p => p.Sinhviens)
                    .HasForeignKey(d => d.Malop)
                    .HasConstraintName("FK__SINHVIEN__MALOP__267ABA7A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
