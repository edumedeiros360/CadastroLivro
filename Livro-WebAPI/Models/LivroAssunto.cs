using System;
using System.Collections.Generic;

namespace Livro_WebAPI.Models
{
    public class LivroAssunto
    {
        public LivroAssunto() { }
        
        public LivroAssunto(int codL, int codAs)
        {
            this.CodL= codL;
            this.CodAs = codAs;
        }

        public int CodL { get; set;}
        public Livro Livro { get; set; }
        public int CodAs { get; set;}
        public Assunto Assunto { get; set; }
    }
}