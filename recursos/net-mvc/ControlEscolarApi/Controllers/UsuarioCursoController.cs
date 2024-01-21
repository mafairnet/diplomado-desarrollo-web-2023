using ControlEscolarApi.Authorization;
using ControlEscolarApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControlEscolarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioCursoController : ControllerBase
    {
        private readonly CatalogoEscolarDbContext _dbContext;

        public UsuarioCursoController(CatalogoEscolarDbContext dbContext) {
            _dbContext = dbContext;
        }

        //Get: api/UsuarioCurso
        [ApiKey]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioCurso>>> GetUsuariosCurso([FromHeader(Name = "X-API-Key")] string apiKey) {
            if (_dbContext.UsuarioCurso == null) {
                return NotFound();
            }
            return await _dbContext.UsuarioCurso.ToListAsync();
        }

        //Get: api/UsuarioCurso/{id}
        [ApiKey]
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioCurso>> GetUsuarioCurso([FromHeader(Name = "X-API-Key")] string apiKey,string id)
        {
            String[] idArray = id.Split('_');

            int idUsuario = int.Parse(idArray[0]);
            int idCurso = int.Parse(idArray[1]);

            if (_dbContext.UsuarioCurso == null)
            {
                return NotFound();
            }

            var usuarioCurso = await _dbContext.UsuarioCurso.FirstOrDefaultAsync(e => e.IdCurso == idCurso && e.IdUsuario == idUsuario);

            if (usuarioCurso == null) {
                return NotFound();
            }

            return usuarioCurso;
        }

        //POST: api/UsuarioCurso
        [ApiKey]
        [HttpPost]
        public async Task<ActionResult<UsuarioCurso>> PostUsuarioCurso([FromHeader(Name = "X-API-Key")] string apiKey,UsuarioCurso usuarioCurso)
        {
            _dbContext.UsuarioCurso.Add(usuarioCurso);
            await _dbContext.SaveChangesAsync();
            var usuarioCursoGuardado = await _dbContext.UsuarioCurso.FirstOrDefaultAsync(e => e.IdUsuario == usuarioCurso.IdUsuario && e.IdCurso == usuarioCurso.IdCurso);
            return usuarioCursoGuardado;
        }

        //DELETE: api/UsuarioCurso/{id}
        [ApiKey]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUsuarioCurso([FromHeader(Name = "X-API-Key")] string apiKey,string id)
        {
            String[] idArray = id.Split('_');

            int idUsuario = int.Parse(idArray[0]);
            int idCurso = int.Parse(idArray[1]);

            if (_dbContext.UsuarioCurso == null) {
                return NotFound();
            }

            var usuarioCurso = await _dbContext.UsuarioCurso.FirstOrDefaultAsync(e => e.IdCurso == idCurso && e.IdUsuario == idUsuario);
            if (usuarioCurso == null) {
                return NotFound();
            }

            _dbContext.UsuarioCurso.Remove(usuarioCurso);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

    }
}
