using System.Threading.Tasks;
using Livro_WebAPI.Models;

namespace Livro_WebAPI.Data
{
    public interface IRepository
    {
        //GERAL
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //Assunto
        Task<Assunto[]> GetAllAssuntosAsync(bool includeAssunto);   
        Task<Assunto> GetAssuntoAsyncByAssuntoId(int assuntoId, bool includeAssunto);     
        Task<Assunto[]> GetAssuntosAsyncByLivroId(int CodL, bool includeLivro);
        
        
        //Autor
        Task<Autor[]> GetAllAutoresAsync(bool includeAutor);
        Task<Autor> GetAutorAsyncByAutorId(int CodAu, bool includeAutor);
        Task<Autor[]> GetAutoresAsyncByLivroId(int CodL, bool includeLivro);

        //Livro

        Task<Livro[]> GetAllLivrosAsync(bool includeLivro);
        Task<Livro> GetLivroAsyncByLivroId(int CodL, bool includeLivro);
        Task<Livro[]> GetLivrosAsyncByAssuntoId(int assuntoId, bool includeAssunto);
        Task<Livro[]> GetLivrosAsyncByAutorId(int CodAu, bool includeAutor);
        
    }
}