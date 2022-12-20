using System;
using System.Collections.Generic;
using Avamed.Database;
using Microsoft.EntityFrameworkCore;

namespace Avamed.Database.Context;

public partial class ApplicationDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;

    }

    public virtual DbSet<Agendamento> Agendamentos { get; set; }

    public virtual DbSet<AgendamentoConfiguracao> AgendamentoConfiguracaos { get; set; }

    public virtual DbSet<Beneficiario> Beneficiarios { get; set; }

    public virtual DbSet<DadosBancario> DadosBancarios { get; set; }

    public virtual DbSet<Especialidade> Especialidades { get; set; }

    public virtual DbSet<Hospital> Hospitals { get; set; }

    public virtual DbSet<Profissional> Profissionals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Sql"));

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
