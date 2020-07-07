using System;
using System.Collections.Generic;

namespace Livro_WebAPI.Models
{
    public class Assunto
    {
        public Assunto() { }
        public Assunto(int codAs, string descricao)
        {
            this.CodAs = codAs;
            this.Descricao = descricao;
            LivroAssunto = new HashSet<LivroAssunto>();
            
        }
  
        public int CodAs { get; set;}
        public string Descricao { get; set; }
        
        public virtual ICollection<LivroAssunto> LivroAssunto { get; set; }
    }
}
