using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using tp_laboratorio.Models;

namespace tp_laboratorio.Context;

public partial class TpLabContext : DbContext
{
    public TpLabContext()
    {
    }

    public TpLabContext(DbContextOptions<TpLabContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actor> Actors { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=tp_lab;user=root;password=250901", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<Actor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("actor");

            entity.Property(e => e.ActorBirthdate).HasColumnName("actor_birthdate");
            entity.Property(e => e.ActorName)
                .HasMaxLength(255)
                .HasColumnName("actor_name");
            entity.Property(e => e.ActorPicture).HasColumnName("actor_picture");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("movie");

            entity.Property(e => e.MovieBudget)
                .HasPrecision(18, 2)
                .HasColumnName("movie_budget");
            entity.Property(e => e.MovieDuration).HasColumnName("movie_duration");
            entity.Property(e => e.MovieGenre)
                .HasMaxLength(255)
                .HasColumnName("movie_genre");
            entity.Property(e => e.MovieName)
                .HasMaxLength(255)
                .HasColumnName("movie_name");

            entity.HasMany(d => d.Actors).WithMany(p => p.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "Movieactor",
                    r => r.HasOne<Actor>().WithMany()
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("movieactor_ibfk_2"),
                    l => l.HasOne<Movie>().WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("movieactor_ibfk_1"),
                    j =>
                    {
                        j.HasKey("MovieId", "ActorId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("movieactor");
                        j.HasIndex(new[] { "ActorId" }, "ActorId");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
