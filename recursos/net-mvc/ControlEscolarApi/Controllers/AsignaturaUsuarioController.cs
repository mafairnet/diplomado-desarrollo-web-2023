using ControlEscolarApi.Authorization;
using ControlEscolarApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControlEscolarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignaturaUsuarioController : ControllerBase
    {
        private readonly CatalogoEscolarDbContext _dbContext;

        public AsignaturaUsuarioController(CatalogoEscolarDbContext dbContext) {
            _dbContext = dbContext;
        }

        //Get: api/AsignaturaUsuario
        [ApiKey]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AsignaturaUsuario>>> GetAsignaturasUsuarios([FromHeader(Name = "X-API-Key")] string apiKey) {
            if (_dbContext.AsignaturaUsuario == null) {
                return NotFound();
            }
            return await _dbContext.AsignaturaUsuario.ToListAsync();
        }

        //Get: api/AsignaturaUsuario/{id}
        [ApiKey]
        [HttpGet("{id}")]
        public async Task<ActionResult<AsignaturaUsuario>> GetAsignaturaUsuario([FromHeader(Name = "X-API-Key")] string apiKey,string id)
        {
            String[] idArray = id.Split('_');

            int idAsignatura = int.Parse(idArray[0]);
            int idUsuario = int.Parse(idArray[1]);

            if (_dbContext.AsignaturaUsuario == null)
            {
                return NotFound();
            }

            var asignaturaUsuario = await _dbContext.AsignaturaUsuario.FirstOrDefaultAsync(e => e.IdAsignatura == idAsignatura && e.IdUsuario == idUsuario);

            if (asignaturaUsuario == null) {
                return NotFound();
            }

            return asignaturaUsuario;
        }

        //POST: api/AsignaturaUsuario
        [ApiKey]
        [HttpPost]
        public async Task<ActionResult<AsignaturaUsuario>> PostAsignaturaUsuario([FromHeader(Name = "X-API-Key")] string apiKey,AsignaturaUsuario asignaturaUsuario)
        {
            _dbContext.AsignaturaUsuario.Add(asignaturaUsuario);
            await _dbContext.SaveChangesAsync();
            var asignaturaUsuarioGuardado = await _dbContext.AsignaturaUsuario.FirstOrDefaultAsync(e => e.IdAsignatura == asignaturaUsuario.IdAsignatura && e.IdUsuario == asignaturaUsuario.IdUsuario);
            return asignaturaUsuarioGuardado;
        }

        //DELETE: api/AsignaturaUsuario/{id}
        [ApiKey]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsignaturaUsuario([FromHeader(Name = "X-API-Key")] string apiKey,string id)
        {
            String[] idArray = id.Split('_');

            int idAsignatura = int.Parse(idArray[0]);
            int idUsuario = int.Parse(idArray[1]);

            if (_dbContext.AsignaturaUsuario == null) {
                return NotFound();
            }

            var asignaturaUsuario = await _dbContext.AsignaturaUsuario.FirstOrDefaultAsync(e => e.IdAsignatura == idAsignatura && e.IdUsuario == idUsuario);
            if (asignaturaUsuario == null) {
                return NotFound();
            }

            _dbContext.AsignaturaUsuario.Remove(asignaturaUsuario);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

    }
}
