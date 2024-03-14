using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Tickets.Model;


namespace Tickets.DAL.DBContext;

public partial class TicketsDbContext : DbContext
{
    public TicketsDbContext()
    {
    }

    public TicketsDbContext(DbContextOptions<TicketsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Equipo> Equipos { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Mensaje> Mensajes { get; set; }

    public virtual DbSet<Solicitud> Solicitudes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.Habilitado).HasColumnName("habilitado");
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Equipo>(entity =>
        {
            entity.HasIndex(e => e.UsuarioId, "IX_Equipos_UsuarioId");

            entity.Property(e => e.Comentario).HasMaxLength(250);
            entity.Property(e => e.Inventario).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Serie).HasMaxLength(100);
            entity.Property(e => e.UsuarioId).HasMaxLength(450);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Equipos).HasForeignKey(d => d.UsuarioId);
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasIndex(e => e.SolicitudId, "IX_Estados_SolicitudId");

            entity.Property(e => e.Comentario).HasMaxLength(250);
            entity.Property(e => e.EstadoActual).HasMaxLength(50);

            entity.HasOne(d => d.Solicitud).WithMany(p => p.Estados).HasForeignKey(d => d.SolicitudId);
        });

        modelBuilder.Entity<Mensaje>(entity =>
        {
            entity.HasIndex(e => e.SolicitudId, "IX_Mensajes_SolicitudId");

            entity.Property(e => e.TxtMensaje).HasMaxLength(50);

            entity.HasOne(d => d.Solicitud).WithMany(p => p.Mensajes).HasForeignKey(d => d.SolicitudId);
        });

        modelBuilder.Entity<Solicitud>(entity =>
        {
            entity.Property(e => e.ContadorMensajes).HasDefaultValue(0);
            entity.Property(e => e.Departamento).HasMaxLength(50);
            entity.Property(e => e.Descripcion).HasMaxLength(250);
            entity.Property(e => e.Equipo).HasMaxLength(250);
            entity.Property(e => e.EstadoActual)
                .HasMaxLength(250)
                .HasDefaultValueSql("''::character varying");
            entity.Property(e => e.Usuario).HasMaxLength(50);
            entity.Property(e => e.UsuarioId).HasMaxLength(450);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
