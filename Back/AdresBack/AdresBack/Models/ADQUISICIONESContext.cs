using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AdresBack.Models
{
    public partial class ADQUISICIONESContext : DbContext
    {
        public ADQUISICIONESContext()
        {
        }

        public ADQUISICIONESContext(DbContextOptions<ADQUISICIONESContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Adquisicion> Adquisiciones { get; set; } = null!;
        public virtual DbSet<Historial> Historial { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adquisicion>(entity =>
            {
                entity.ToTable("ADQUISICION");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BienesServicios)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("BIENES_SERVICIOS");

                entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");

                entity.Property(e => e.Documentacion)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("DOCUMENTACION");

                entity.Property(e => e.EntidadProveedora)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("ENTIDAD_PROVEEDORA");

                entity.Property(e => e.FechaAdquisicion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_ADQUISICION");

                entity.Property(e => e.Presupuesto)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("PRESUPUESTO");

                entity.Property(e => e.UnidadAdministrativa)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("UNIDAD_ADMINISTRATIVA");

                entity.Property(e => e.ValorTotal)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("VALOR_TOTAL");

                entity.Property(e => e.ValorUnitario)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("VALOR_UNITARIO");
            });

            modelBuilder.Entity<Historial>(entity =>
            {
                entity.ToTable("HISTORIAL");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdAdquisicion).HasColumnName("ID_ADQUISICION");

                entity.Property(e => e.Descripcion)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("FECHA");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TIPO")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
