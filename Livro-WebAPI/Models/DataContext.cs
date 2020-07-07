
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Livro_WebAPI.Models
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<Assunto> Assunto { get; set; }
        public virtual DbSet<Autor> Autor { get; set; }
        public virtual DbSet<Livro> Livro { get; set; }
        public virtual DbSet<LivroAssunto> LivroAssunto { get; set; }
        public virtual DbSet<LivroAutor> LivroAutor { get; set; }
        public virtual DbSet<VwLivrosPorAutor> VwLivrosPorAutor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlite("DefaultConn");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assunto>(entity =>
            {
                entity.HasKey(e => e.CodAs)
                    .HasName("PK__Assunto__F41597613B295FF0");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Autor>(entity =>
            {
                entity.HasKey(e => e.CodAu)
                    .HasName("PK__Autor__F4159767AE959664");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<Livro>(entity =>
            {
                entity.HasKey(e => e.CodL)
                    .HasName("PK__Livro__A25C455FA87179C0");

                entity.Property(e => e.AnoPublicacao).HasColumnType("numeric(4, 0)");

                entity.Property(e => e.Editora)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Preco).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<LivroAssunto>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Livro_Assunto");

                entity.HasIndex(e => e.CodAs)
                    .HasName("Livro_assunto_FKIndex2");

                entity.HasIndex(e => e.CodL)
                    .HasName("Livro_assunto_FKIndex1");

                entity.Property(e => e.CodAs).HasColumnName("Assunto_CodAs");

                entity.Property(e => e.CodL).HasColumnName("Livro_Codl");

                entity.HasOne(d => d.Assunto)
                    .WithMany(p => p.LivroAssunto)
                    .HasForeignKey(d => d.CodAs)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Livro_Assunto_Assunto");

                entity.HasOne(d => d.Livro)
                    .WithMany(p => p.LivroAssunto)
                    .HasForeignKey(d => d.CodL)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Livro_Assunto_Livro");
            });

            modelBuilder.Entity<LivroAutor>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Livro_Autor");

                entity.HasIndex(e => e.Autor)
                    .HasName("Livro_Autor_FKIndex2");

                entity.HasIndex(e => e.Livro)
                    .HasName("Livro_Autor_FKIndex1");

                entity.Property(e => e.CodAu).HasColumnName("Autor_CodAu");

                entity.Property(e => e.CodL).HasColumnName("Livro_Codl");

                entity.HasOne(d => d.Autor)
                    .WithMany(p => p.LivroAutor)
                    .HasForeignKey(d => d.CodAu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Livro_Autor_Autor");

                entity.HasOne(d => d.Livro)
                    .WithMany(p => p.LivroAutor)
                    .HasForeignKey(d => d.CodAu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Livro_Autor_Livro");
            });

            modelBuilder.Entity<VwLivrosPorAutor>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VW_LIVROS_POR_AUTOR");

                entity.Property(e => e.Assunto)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Autor)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
