using System;
using System.Collections.Generic;
using HernandezMargot_API_M.Models;
using Microsoft.EntityFrameworkCore;

namespace HernandezMargot_API_M.Data;

public partial class ChinookModificadaContext : DbContext
{
    public ChinookModificadaContext()
    {
    }

    public ChinookModificadaContext(DbContextOptions<ChinookModificadaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Album> Albums { get; set; }

    public virtual DbSet<Artistum> Artista { get; set; }

    public virtual DbSet<Genero> Generos { get; set; }

    public virtual DbSet<Pistum> Pista { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=Chinook-connection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Album>(entity =>
        {
            entity.HasKey(e => e.AlbumId).HasName("PK__Album__97B4BE3700CCD07E");

            entity.HasOne(d => d.Artista).WithMany(p => p.Albums)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Album__ArtistaId__38996AB5");
        });

        modelBuilder.Entity<Artistum>(entity =>
        {
            entity.HasKey(e => e.ArtistaId).HasName("PK__Artista__1DC48255DD41CA57");
        });

        modelBuilder.Entity<Genero>(entity =>
        {
            entity.HasKey(e => e.GeneroId).HasName("PK__Genero__A99D0248299481C0");
        });

        modelBuilder.Entity<Pistum>(entity =>
        {
            entity.HasKey(e => e.PistaId).HasName("PK__Pista__56A9FDADB6FEEC9C");

            entity.HasOne(d => d.Album).WithMany(p => p.Pista)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pista__AlbumId__3D5E1FD2");

            entity.HasOne(d => d.Genero).WithMany(p => p.Pista)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pista__GeneroId__3E52440B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
