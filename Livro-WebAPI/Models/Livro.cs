using System;
using System.Collections.Generic;

namespace Livro_WebAPI.Models
{
    public class Livro
    {
        public Livro() { }
        public Livro(int codL, string titulo, int codAs, int codAu)
        {
            this.CodL = codL;
            this.Titulo = titulo;
            this.CodAs = codAs;
            this.CodAu = codAu;
        }

        public int CodL { get; set;}
        public string Titulo { get; set; }
        public int CodAs { get; set;}
        public int CodAu { get; set;}
        public string Editora { get; set;}
        public int Edicao { get; set; }
        public int AnoPublicacao { get; set; }
        public decimal? Preco { get; set; }

        public virtual ICollection<LivroAssunto> LivroAssunto { get; set; }
        public virtual ICollection<LivroAutor> LivroAutor { get; set; }
    }
}
