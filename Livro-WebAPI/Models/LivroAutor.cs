using System;
using System.Collections.Generic;

namespace Livro_WebAPI.Models
{
    public class LivroAutor
    {
        public LivroAutor() { }
        
        public LivroAutor(int codL, int codAu)
        {
            this.CodL= codL;
            this.CodAu = codAu;
        }
        
        public int CodL { get; set;}
        public Livro Livro { get; set; }
        public int CodAu { get; set;}
        public Autor Autor { get; set; }
    }
}