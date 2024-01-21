using ControlEscolarApi.Authorization;
using ControlEscolarApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControlEscolarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioCarreraController : ControllerBase
    {
        private readonly CatalogoEscolarDbContext _dbContext;

        public UsuarioCarreraController(CatalogoEscolarDbContext dbContext) {
            _dbContext = dbContext;
        }

        //Get: api/UsuarioCarrera
        [ApiKey]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioCarrera>>> GetUsuarioCarreras([FromHeader(Name = "X-API-Key")] string apiKey) {
            if (_dbContext.UsuarioCarrera == null) {
                return NotFound();
            }
            return await _dbContext.UsuarioCarrera.ToListAsync();
        }

        //Get: api/UsuarioCarrera/{id}
        [ApiKey]
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioCarrera>> GetUsuarioCarrera([FromHeader(Name = "X-API-Key")] string apiKey,string id)
        {
            String[] idArray = id.Split('_');

            int idUsuario = int.Parse(idArray[0]);
            int idCarrera = int.Parse(idArray[1]);

            if (_dbContext.UsuarioCarrera == null)
            {
                return NotFound();
            }

            var usuarioCarrera = await _dbContext.UsuarioCarrera.FirstOrDefaultAsync(e => e.IdUsuario == idUsuario && e.IdCarrera == idCarrera);

            if (usuarioCarrera == null) {
                return NotFound();
            }

            return usuarioCarrera;
        }

        //POST: api/UsuarioCarrera
        [ApiKey]
        [HttpPost]
        public async Task<ActionResult<UsuarioCarrera>> PostUsuarioCarrera([FromHeader(Name = "X-API-Key")] string apiKey,UsuarioCarrera usuarioCarrera)
        {
            _dbContext.UsuarioCarrera.Add(usuarioCarrera);
            await _dbContext.SaveChangesAsync();
            var usuarioCarreraGuardado = await _dbContext.UsuarioCarrera.FirstOrDefaultAsync(e => e.IdUsuario == usuarioCarrera.IdUsuario && e.IdCarrera == usuarioCarrera.IdCarrera);
            return usuarioCarreraGuardado;
        }

        //DELETE: api/UsuarioCarrera/{id}
        [ApiKey]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUsuarioCarrera([FromHeader(Name = "X-API-Key")] string apiKey,string id)
        {
            String[] idArray = id.Split('_');

            int idUsuario = int.Parse(idArray[0]);
            int idCarrera = int.Parse(idArray[1]);

            if (_dbContext.UsuarioCarrera == null) {
                return NotFound();
            }

            var usuarioCarrera = await _dbContext.UsuarioCarrera.FirstOrDefaultAsync(e => e.IdUsuario == idUsuario && e.IdCarrera == idCarrera);
            if (usuarioCarrera == null) {
                return NotFound();
            }

            _dbContext.UsuarioCarrera.Remove(usuarioCarrera);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

    }
}
