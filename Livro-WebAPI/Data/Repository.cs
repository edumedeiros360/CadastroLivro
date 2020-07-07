
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Livro_WebAPI.Models;

namespace Livro_WebAPI.Data
{

    public class Repository : IRepository
    {
        
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Assunto[]> GetAllAssuntosAsync(bool includeLivro = false)
        {
            IQueryable<Assunto> query = _context.Assuntos;

            if (includeLivro)
            {
                query = query.Include(pe => pe.LivroAssunto)
                             .ThenInclude(ad => ad.Livro);

                             //.ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking()
                         .OrderBy(c => c.CodAs);

            return await query.ToArrayAsync();
        }
        public async Task<Assunto> GetAssuntoAsyncByAssuntoId(int codAs, bool includeLivro)
        {
            IQueryable<Assunto> query = _context.Assuntos;

            if (includeLivro)
            {
                query = query.Include(a => a.LivroAssunto)
                             .ThenInclude(ad => ad.Livro);

                             //.ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking()
                         .OrderBy(assunto => assunto.CodAs)
                         .Where(assunto => assunto.CodAs == codAs);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Assunto[]> GetAssuntosAsyncByLivroId(int codL, bool includeLivro)
        {
            IQueryable<Assunto> query = _context.Assuntos;

            if (includeLivro)
            {
                query = query.Include(p => p.LivroAssunto)
                             .ThenInclude(ad => ad.Livro);

                             //.ThenInclude(d => d.Autor);
            }

            query = query.AsNoTracking()
                         .OrderBy(assunto => assunto.CodAs)
                         .Where(assunto => assunto.LivroAssunto.Any(ad => ad.CodL == codL));

            return await query.ToArrayAsync();
        }


        public async Task<Autor[]> GetAllAutoresAsync(bool includeLivro = false)
        {
            IQueryable<Autor> query = _context.Autores;

            if (includeLivro)
            {
                query = query.Include(pe => pe.LivroAutor)
                             .ThenInclude(ad => ad.Livro);
                            // .ThenInclude(d => d.);
            }

            query = query.AsNoTracking()
                         .OrderBy(c => c.CodAu);

            return await query.ToArrayAsync();
        }
        public async Task<Autor> GetAutorAsyncByAutorId(int codAu, bool includeLivro)
        {                        
            IQueryable<Autor> query = _context.Autores;

            if (includeLivro)
            {
                query = query.Include(a => a.LivroAutor)
                             .ThenInclude(ad => ad.Livro);

                             //.ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking()
                         .OrderBy(autor => autor.CodAu)
                         .Where(autor => autor.CodAu == codAu);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Autor[]> GetAutoresAsyncByLivroId(int CodL, bool includeLivro)
        {
            IQueryable<Autor> query = _context.Autores;

            if (includeLivro)
            {
                query = query.Include(p => p.LivroAutor)
                             .ThenInclude(ad => ad.Livro);

                             //.ThenInclude(d => d.Autor);
            }

            query = query.AsNoTracking()
                         .OrderBy(autor => autor.CodAu)
                         .Where(autor => autor.LivroAutor.Any(ad => ad.CodL == CodL));

            return await query.ToArrayAsync();
        }
        


public async Task<Livro[]> GetAllLivrosAsync(bool includeLivro = false)
        {
            IQueryable<Livro> query = _context.Livros;

            if (includeLivro)
            {
                query = query.Include(pe => pe.LivroAutor)
                             .ThenInclude(ad => ad.Livro);

                query = query.Include(pf => pf.LivroAssunto)
                             .ThenInclude(af => af.Assunto);
            }

            query = query.AsNoTracking()
                         .OrderBy(c => c.CodL);

            return await query.ToArrayAsync();
        }
        public async Task<Livro> GetLivroAsyncByLivroId(int codL, bool includeLivro)
        {                        
            IQueryable<Livro> query = _context.Livros;

            if (includeLivro)
            {
                query = query.Include(pe => pe.LivroAutor)
                             .ThenInclude(ad => ad.Livro);

                query = query.Include(pf => pf.LivroAssunto)
                             .ThenInclude(af => af.Assunto);

                             //.ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking()
                         .OrderBy(livro => livro.CodL)
                         .Where(livro => livro.CodL == codL);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Livro[]> GetLivrosAsyncByAutorId(int codAu, bool includeLivro)
        {
            IQueryable<Livro> query = _context.Livros;

            if (includeLivro)
            {
                query = query.Include(pe => pe.LivroAutor)
                             .ThenInclude(ad => ad.Livro);

                query = query.Include(pf => pf.LivroAssunto)
                             .ThenInclude(af => af.Assunto);

                             //.ThenInclude(d => d.Autor);
            }

            query = query.AsNoTracking()
                         .OrderBy(livro => livro.CodL)
                         .Where(livro => livro.LivroAutor.Any(ad => ad.CodAu == codAu));

            return await query.ToArrayAsync();
        }

 public async Task<Livro[]> GetLivrosAsyncByAssuntoId(int codAs, bool includeLivro)
        {
            IQueryable<Livro> query = _context.Livros;

            if (includeLivro)
            {
                query = query.Include(pe => pe.LivroAutor)
                             .ThenInclude(ad => ad.Livro);

                query = query.Include(pf => pf.LivroAssunto)
                             .ThenInclude(af => af.Assunto);

                             //.ThenInclude(d => d.Autor);
            }

            query = query.AsNoTracking()
                         .OrderBy(livro => livro.CodL)
                         .Where(livro => livro.LivroAssunto.Any(ad => ad.CodAs == codAs));

            return await query.ToArrayAsync();
        }

    }

}
