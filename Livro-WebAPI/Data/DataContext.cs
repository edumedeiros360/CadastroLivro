

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Livro_WebAPI.Models;

namespace Livro_WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) { }        
        public DbSet<Assunto> Assuntos { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<LivroAssunto> LivrosAssuntos { get; set; }
        public DbSet<LivroAssunto> LivrosAutores { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            builder.Entity<LivroAssunto>();
            
            builder.Entity<LivroAutor>();  

            builder.Entity<Autor>();
            
            builder.Entity<Livro>();
            
            builder.Entity<Assunto>();

            builder.Entity<LivroAssunto>();

            builder.Entity<LivroAutor>();
        }
    }
}

