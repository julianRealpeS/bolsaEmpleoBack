using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace bolsaEmpleoBack.Models;

public partial class BolsaEmpleoDbContext : DbContext
{
    public BolsaEmpleoDbContext()
    {
    }

    public BolsaEmpleoDbContext(DbContextOptions<BolsaEmpleoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ciudadano> Ciudadanos { get; set; }

    public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }

    public virtual DbSet<VacanteOfertadum> VacanteOfertada { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ciudadano>(entity =>
        {
            entity.ToTable("ciudadano");

            entity.Property(e => e.CiudadanoId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("ciudadano_id");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.AspiracionSalarial)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("aspiracion_salarial");
            entity.Property(e => e.Cedula)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cedula");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo_electronico");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombres");
            entity.Property(e => e.Profesion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("profesion");
            entity.Property(e => e.TipoDocumentoId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("tipo_documento_id");

            entity.HasOne(d => d.TipoDocumento).WithMany(p => p.Ciudadanos)
                .HasForeignKey(d => d.TipoDocumentoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ciudadano_tipo_documento");
        });

        modelBuilder.Entity<TipoDocumento>(entity =>
        {
            entity.ToTable("tipo_documento");

            entity.Property(e => e.TipoDocumentoId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("tipo_documento_id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<VacanteOfertadum>(entity =>
        {
            entity.HasKey(e => e.VacanteOfertadaId);

            entity.ToTable("vacante_ofertada");

            entity.Property(e => e.VacanteOfertadaId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("vacante_ofertada_id");
            entity.Property(e => e.Cargo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cargo");
            entity.Property(e => e.CiudadanoId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("ciudadano_id");
            entity.Property(e => e.Codigo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("codigo");
            entity.Property(e => e.Descripcion)
                .HasColumnType("ntext")
                .HasColumnName("descripcion");
            entity.Property(e => e.Empresa)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("empresa");
            entity.Property(e => e.Salario)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("salario");

            entity.HasOne(d => d.Ciudadano).WithMany(p => p.VacanteOfertada)
                .HasForeignKey(d => d.CiudadanoId)
                .HasConstraintName("FK_vacante_ofertada_ciudadano");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
