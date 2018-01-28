using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebNetCore2.Models2
{
    public partial class FisioDbContext : DbContext
    {
        public FisioDbContext(DbContextOptions<FisioDbContext> options)
        : base(options)
        { }

        public virtual DbSet<Citas> Citas { get; set; }
        public virtual DbSet<Clinicas> Clinicas { get; set; }
        public virtual DbSet<Datosclinicos> Datosclinicos { get; set; }
        public virtual DbSet<Dolencias> Dolencias { get; set; }
        public virtual DbSet<Historicologins> Historicologins { get; set; }
        public virtual DbSet<Pacientes> Pacientes { get; set; }
        public virtual DbSet<Sesiones> Sesiones { get; set; }
        public virtual DbSet<Tiposdatosclinicos> Tiposdatosclinicos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=eu-cdbr-west-01.cleardb.com;User Id=bb2bf97cab90ee;Password=93bca23c;Database=heroku_acabb8e58c52d34");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Citas>(entity =>
            {
                entity.ToTable("citas");

                entity.HasIndex(e => e.IdClinica)
                    .HasName("fk_clinicas_citas_idx");

                entity.HasIndex(e => e.IdPaciente)
                    .HasName("fk_pacientes_citas_idx");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("fk_usuarios_citas_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("fechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.HoraFin)
                    .HasColumnName("horaFin")
                    .HasColumnType("time");

                entity.Property(e => e.HoraInicio)
                    .HasColumnName("horaInicio")
                    .HasColumnType("time");

                entity.Property(e => e.IdClinica)
                    .HasColumnName("idClinica")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdPaciente)
                    .HasColumnName("idPaciente")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("idUsuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Observaciones)
                    .HasColumnName("observaciones")
                    .HasMaxLength(1000);

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.Citas)
                    .HasForeignKey(d => d.IdClinica)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clinicas_citas");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Citas)
                    .HasForeignKey(d => d.IdPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pacientes_citas");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Citas)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_usuarios_citas");
            });

            modelBuilder.Entity<Clinicas>(entity =>
            {
                entity.ToTable("clinicas");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cif)
                    .HasColumnName("cif")
                    .HasMaxLength(9);

                entity.Property(e => e.CodigoPostal)
                    .HasColumnName("codigoPostal")
                    .HasColumnType("int(5)");

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasMaxLength(60);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("fechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.Localidad)
                    .HasColumnName("localidad")
                    .HasMaxLength(20);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(255);

                entity.Property(e => e.Provincia)
                    .HasColumnName("provincia")
                    .HasMaxLength(20);

                entity.Property(e => e.TlfFijo)
                    .HasColumnName("tlfFijo")
                    .HasColumnType("int(9)");

                entity.Property(e => e.TlfMovil)
                    .HasColumnName("tlfMovil")
                    .HasColumnType("int(9)");
            });

            modelBuilder.Entity<Datosclinicos>(entity =>
            {
                entity.ToTable("datosclinicos");

                entity.HasIndex(e => e.IdPaciente)
                    .HasName("fk_pacientes_datosclinicos_idx");

                entity.HasIndex(e => e.IdTipoDatoClinico)
                    .HasName("fk_tiposdatosclinicos_datosclinicos_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdPaciente)
                    .HasColumnName("idPaciente")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTipoDatoClinico)
                    .HasColumnName("idTipoDatoClinico")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Valor)
                    .IsRequired()
                    .HasColumnName("valor")
                    .HasMaxLength(300);

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Datosclinicos)
                    .HasForeignKey(d => d.IdPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pacientes_datosclinicos");

                entity.HasOne(d => d.IdTipoDatoClinicoNavigation)
                    .WithMany(p => p.Datosclinicos)
                    .HasForeignKey(d => d.IdTipoDatoClinico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tiposdatosclinicos_datosclinicos");
            });

            modelBuilder.Entity<Dolencias>(entity =>
            {
                entity.ToTable("dolencias");

                entity.HasIndex(e => e.IdPaciente)
                    .HasName("fk_dolencias_pacientes_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ApreciacionDolor)
                    .HasColumnName("apreciacionDolor")
                    .HasColumnType("int(1)");

                entity.Property(e => e.ComoLeDuele)
                    .HasColumnName("comoLeDuele")
                    .HasMaxLength(100);

                entity.Property(e => e.CuandoDuele)
                    .HasColumnName("cuandoDuele")
                    .HasMaxLength(100);

                entity.Property(e => e.DesdeCuandoDuele)
                    .HasColumnName("desdeCuandoDuele")
                    .HasMaxLength(100);

                entity.Property(e => e.DondeDuele)
                    .HasColumnName("dondeDuele")
                    .HasMaxLength(100);

                entity.Property(e => e.EscalaAlivio)
                    .HasColumnName("escalaAlivio")
                    .HasColumnType("int(1)");

                entity.Property(e => e.EscalaDisposicionAnimo)
                    .HasColumnName("escalaDisposicionAnimo")
                    .HasColumnType("int(1)");

                entity.Property(e => e.EscalaDolor)
                    .HasColumnName("escalaDolor")
                    .HasColumnType("int(1)");

                entity.Property(e => e.IdPaciente)
                    .HasColumnName("idPaciente")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Intensidad)
                    .HasColumnName("intensidad")
                    .HasColumnType("int(1)");

                entity.Property(e => e.Observaciones)
                    .HasColumnName("observaciones")
                    .HasMaxLength(1000);

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Dolencias)
                    .HasForeignKey(d => d.IdPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_dolencias_pacientes");
            });

            modelBuilder.Entity<Historicologins>(entity =>
            {
                entity.ToTable("historicologins");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("fk_usuarios_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("idUsuario")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Historicologins)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_usuarios_historicologins");
            });

            modelBuilder.Entity<Pacientes>(entity =>
            {
                entity.ToTable("pacientes");

                entity.HasIndex(e => e.IdClinica)
                    .HasName("fk_clinicas_pacientes_idx");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("fk_usuarios_pacientes_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ActividadFisica)
                    .HasColumnName("actividadFisica")
                    .HasMaxLength(200);

                entity.Property(e => e.Altura)
                    .HasColumnName("altura")
                    .HasColumnType("decimal(4,2)");

                entity.Property(e => e.CodigoPostal)
                    .HasColumnName("codigoPostal")
                    .HasColumnType("int(5)");

                entity.Property(e => e.Consentimiento)
                    .HasColumnName("consentimiento")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Diagnostico)
                    .HasColumnName("diagnostico")
                    .HasMaxLength(300);

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasMaxLength(60);

                entity.Property(e => e.Dni)
                    .HasColumnName("dni")
                    .HasMaxLength(9);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.FechaBaja)
                    .HasColumnName("fechaBaja")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("fechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdClinica)
                    .HasColumnName("idClinica")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("idUsuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Localidad)
                    .HasColumnName("localidad")
                    .HasMaxLength(20);

                entity.Property(e => e.Nacionalidad)
                    .HasColumnName("nacionalidad")
                    .HasMaxLength(20);

                entity.Property(e => e.NombreApellidos)
                    .IsRequired()
                    .HasColumnName("nombreApellidos")
                    .HasMaxLength(150);

                entity.Property(e => e.Peso)
                    .HasColumnName("peso")
                    .HasColumnType("decimal(6,2)");

                entity.Property(e => e.Profesion)
                    .HasColumnName("profesion")
                    .HasMaxLength(60);

                entity.Property(e => e.Provincia)
                    .HasColumnName("provincia")
                    .HasMaxLength(20);

                entity.Property(e => e.TlfFijo)
                    .HasColumnName("tlfFijo")
                    .HasColumnType("int(9)");

                entity.Property(e => e.TlfMovil)
                    .HasColumnName("tlfMovil")
                    .HasColumnType("int(9)");

                entity.Property(e => e.TratamientoFisioterapia)
                    .HasColumnName("tratamientoFisioterapia")
                    .HasMaxLength(3000);

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.IdClinica)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pacientes_clinicas");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pacientes_usuarios");
            });

            modelBuilder.Entity<Sesiones>(entity =>
            {
                entity.ToTable("sesiones");

                entity.HasIndex(e => e.IdPaciente)
                    .HasName("fk_sesiones_idx");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("fk_usuarios_sesiones_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Coste)
                    .HasColumnName("coste")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("fechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdPaciente)
                    .HasColumnName("idPaciente")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("idUsuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tratamiento)
                    .IsRequired()
                    .HasColumnName("tratamiento")
                    .HasMaxLength(3000);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Sesiones)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_usuarios_sesiones");
            });

            modelBuilder.Entity<Tiposdatosclinicos>(entity =>
            {
                entity.ToTable("tiposdatosclinicos");

                entity.HasIndex(e => e.IdClinica)
                    .HasName("fk_clinicas_tiposdatosclinicos_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DescripcionTipo)
                    .HasColumnName("descripcionTipo")
                    .HasMaxLength(1000);

                entity.Property(e => e.IdClinica)
                    .HasColumnName("idClinica")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NombreTipo)
                    .IsRequired()
                    .HasColumnName("nombreTipo")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.Tiposdatosclinicos)
                    .HasForeignKey(d => d.IdClinica)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clinicas_tiposdatosclinicos");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.ToTable("usuarios");

                entity.HasIndex(e => e.IdClinica)
                    .HasName("fk_usuarios_clinicas_idx");

                entity.HasIndex(e => e.Usuario)
                    .HasName("usuario_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.FechaBaja)
                    .HasColumnName("fechaBaja")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("fechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdClinica)
                    .HasColumnName("idClinica")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NombreApellidos)
                    .IsRequired()
                    .HasColumnName("nombreApellidos")
                    .HasMaxLength(150);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(255);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasColumnName("usuario")
                    .HasMaxLength(10);

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdClinica)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clinicas_usuarios");
            });
        }
    }
}
