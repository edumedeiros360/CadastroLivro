using System;
using System.Collections.Generic;

namespace Livro_WebAPI.Models
{
    

    public partial class Autor
    {
        public Autor(){}

        public Autor(int codAu, string nome)
        {   
            this.CodAu = codAu;
            this.Nome = nome;
            LivroAutor = new HashSet<LivroAutor>();
        }
        
        public int CodAu { get; set;}
        public string Nome { get; set; }

        public virtual ICollection<LivroAutor> LivroAutor { get; set; }
    }
}
