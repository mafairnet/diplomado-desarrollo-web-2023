using ControlEscolarApi.Authorization;
using ControlEscolarApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControlEscolarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalificacionCursoUsuarioController : ControllerBase
    {
        private readonly CatalogoEscolarDbContext _dbContext;

        public CalificacionCursoUsuarioController(CatalogoEscolarDbContext dbContext) {
            _dbContext = dbContext;
        }

        //Get: api/CalificacionCursoUsuario
        [ApiKey]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CalificacionCursoUsuario>>> GetCalificacionesCursoUsuario([FromHeader(Name = "X-API-Key")] string apiKey) {
            if (_dbContext.CalificacionCursoUsuario == null) {
                return NotFound();
            }
            return await _dbContext.CalificacionCursoUsuario.ToListAsync();
        }

        //Get: api/CalificacionCursoUsuario/{id}
        [ApiKey]
        [HttpGet("{id}")]
        public async Task<ActionResult<CalificacionCursoUsuario>> GetCalificacionCursoUsuario([FromHeader(Name = "X-API-Key")] string apiKey,string id)
        {
            String[] idArray = id.Split('_');

            int idUsuario = int.Parse(idArray[0]);
            int idCurso = int.Parse(idArray[1]);
            int idCalificacion = int.Parse(idArray[2]);

            if (_dbContext.CalificacionCursoUsuario == null)
            {
                return NotFound();
            }

            var calificacionCursoUsuario = await _dbContext.CalificacionCursoUsuario.FirstOrDefaultAsync(e => e.IdCurso == idCurso && e.IdUsuario == idUsuario && e.IdCalificacion == idCalificacion);

            if (calificacionCursoUsuario == null) {
                return NotFound();
            }

            return calificacionCursoUsuario;
        }

        //POST: api/CalificacionCursoUsuario
        [ApiKey]
        [HttpPost]
        public async Task<ActionResult<CalificacionCursoUsuario>> PostCalificacionCursoUsuario([FromHeader(Name = "X-API-Key")] string apiKey,CalificacionCursoUsuario calificacionCursoUsuario)
        {
            _dbContext.CalificacionCursoUsuario.Add(calificacionCursoUsuario);
            await _dbContext.SaveChangesAsync();
            var calificacionCursoUsuarioGuardado = await _dbContext.CalificacionCursoUsuario.FirstOrDefaultAsync(e => e.IdCurso == calificacionCursoUsuario.IdCurso && e.IdUsuario == calificacionCursoUsuario.IdUsuario && e.IdCalificacion == calificacionCursoUsuario.IdCalificacion);
            return calificacionCursoUsuarioGuardado;
        }

        //DELETE: api/CalificacionCursoUsuario/{id}
        [ApiKey]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCalificacionCursoUsuario([FromHeader(Name = "X-API-Key")] string apiKey,string id)
        {
            String[] idArray = id.Split('_');

            int idUsuario = int.Parse(idArray[0]);
            int idCurso = int.Parse(idArray[1]);
            int idCalificacion = int.Parse(idArray[2]);

            if (_dbContext.CalificacionCursoUsuario == null) {
                return NotFound();
            }

            var calificacionCursoUsuario = await _dbContext.CalificacionCursoUsuario.FirstOrDefaultAsync(e => e.IdCurso == idCurso && e.IdUsuario == idUsuario && e.IdCalificacion == idCalificacion);
            if (calificacionCursoUsuario == null) {
                return NotFound();
            }

            _dbContext.CalificacionCursoUsuario.Remove(calificacionCursoUsuario);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

    }
}
