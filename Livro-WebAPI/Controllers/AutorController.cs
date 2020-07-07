using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Livro_WebAPI.Data;
using Livro_WebAPI.Models;

namespace Livro_WebAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AutorController : ControllerBase
    {
        private readonly IRepository _repo;

        public AutorController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllAutoresAsync(true);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }



        [HttpGet("{codAu}")]
        public async Task<IActionResult> GetByAutorId(int CodAu)
        {
            try
            {
                var result = await _repo.GetAutorAsyncByAutorId(CodAu, true);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("ByLivro/{codL}")]
        public async Task<IActionResult> GetByLivroId(int CodL)
        {
            try
            {
                var result = await _repo.GetAutoresAsyncByLivroId(CodL, true);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> post(Autor model)
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

        [HttpPut("{codAu}")]
        public async Task<IActionResult> put(int CodAu, Autor model)
        {
            try
            {
                var Autor = await _repo.GetAutorAsyncByAutorId(CodAu, false);
                if(Autor == null) return NotFound();

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

        [HttpDelete("{codAu}")]
        public async Task<IActionResult> delete(int CodAu)
        {
            try
            {
                var Autor = await _repo.GetAutorAsyncByAutorId(CodAu, false);
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