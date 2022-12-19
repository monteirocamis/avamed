using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Avamed.Database;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agendamento> Agendamentos { get; set; }

    public virtual DbSet<AgendamentoConfiguracao> AgendamentoConfiguracaos { get; set; }

    public virtual DbSet<Beneficiario> Beneficiarios { get; set; }

    public virtual DbSet<DadosBancario> DadosBancarios { get; set; }

    public virtual DbSet<Especialidade> Especialidades { get; set; }

    public virtual DbSet<Hospital> Hospitals { get; set; }

    public virtual DbSet<Profissional> Profissionals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agendamento>(entity =>
        {
            entity.HasOne(d => d.IdBeneficiarioNavigation).WithMany(p => p.Agendamentos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Agendamento_Beneficiario");

            entity.HasOne(d => d.IdEspecialidadeNavigation).WithMany(p => p.Agendamentos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Agendamento_Especialidade");

            entity.HasOne(d => d.IdHospitalNavigation).WithMany(p => p.Agendamentos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Agendamento_Hospital");

            entity.HasOne(d => d.IdProfissionalNavigation).WithMany(p => p.Agendamentos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Agendamento_Profissional");
        });

        modelBuilder.Entity<AgendamentoConfiguracao>(entity =>
        {
            entity.HasOne(d => d.IdEspecialidadeNavigation).WithMany(p => p.AgendamentoConfiguracaos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AgendamentoConfiguracao_Especialidade");

            entity.HasOne(d => d.IdHospitalNavigation).WithMany(p => p.AgendamentoConfiguracaos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AgendamentoConfiguracao_Hospital");

            entity.HasOne(d => d.IdProfissionalNavigation).WithMany(p => p.AgendamentoConfiguracaos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AgendamentoConfiguracao_Profissional");
        });

        modelBuilder.Entity<DadosBancario>(entity =>
        {
            entity.HasOne(d => d.IdProfissionalNavigation).WithMany(p => p.DadosBancarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DadosBancarios_Profissional");
        });

        modelBuilder.Entity<Hospital>(entity =>
        {
            entity.HasKey(e => e.IdHospital).HasName("PK__Hospital__AF70C2B217C3306F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
