using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Livro_WebAPI.Data;
using Livro_WebAPI.Models;

namespace Livro_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssuntoController : ControllerBase
    {
        private readonly IRepository _repo;

        public AssuntoController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllAssuntosAsync(true);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
        
        [HttpGet("{codAs}")]
        public async Task<IActionResult> GetByAssuntoId(int codAs)
        {
            try
            {
                var result = await _repo.GetAssuntoAsyncByAssuntoId(codAs, true);
                
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
                var result = await _repo.GetAssuntosAsyncByLivroId(CodL, false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> post(Assunto model)
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

        [HttpPut("{codAs}")]
        public async Task<IActionResult> put(int assuntoId, Assunto model)
        {
            try
            {
                var assunto = await _repo.GetAssuntoAsyncByAssuntoId(assuntoId, false);
                if(assunto == null) return NotFound();

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

        [HttpDelete("{codAs}")]
        public async Task<IActionResult> delete(int assuntoId)
        {
            try
            {
                var assunto = await _repo.GetAssuntoAsyncByAssuntoId(assuntoId, false);
                if(assunto == null) return NotFound();

                _repo.Delete(assunto);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok(new { message = "Deletado"});
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