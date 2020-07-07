using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Livro_WebAPI.Data;
using Livro_WebAPI.Models;

namespace Livro_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly IRepository _repo;

        public LivroController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllLivrosAsync(true);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("{codL}")]
        public async Task<IActionResult> GetByLivroId(int CodL)
        {
            try
            {
                var result = await _repo.GetLivroAsyncByLivroId(CodL, true);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("ByAssunto/{codAs}")]
        public async Task<IActionResult> GetByAssuntoId(int assuntoId)
        {
            try
            {
                var result = await _repo.GetLivrosAsyncByAssuntoId(assuntoId, true);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
        
        [HttpGet("ByAutor/{codAu}")]
        public async Task<IActionResult> GetByAutorId(int CodAu)
        {
            try
            {
                var result = await _repo.GetLivrosAsyncByAutorId(CodAu, true);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> post(Livro model)
        {
            try
            {
                _repo.Add(model);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok(model);
                }                
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

        [HttpPut("{codL}")]
        public async Task<IActionResult> put(int CodL, Livro model)
        {
            try
            {
                //Verificar Eduardo Medeiros
                var Livro = await _repo.GetLivroAsyncByLivroId(CodL, false);
                if(Livro == null) return NotFound();

                _repo.Update(model);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok(model);
                }                
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

        [HttpDelete("{codL}")]
        public async Task<IActionResult> delete(int CodL)
        {
            try
            {
                //Verificar Eduardo Medeiros
                var Autor = await _repo.GetLivroAsyncByLivroId(CodL, false);
                if(Autor == null) return NotFound();

                _repo.Delete(Autor);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok("Deletado");
                }                
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }
    }
}