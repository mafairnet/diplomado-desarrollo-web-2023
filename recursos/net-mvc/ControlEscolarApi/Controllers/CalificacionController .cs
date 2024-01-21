using ControlEscolarApi.Authorization;
using ControlEscolarApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControlEscolarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalificacionController : ControllerBase
    {
        private readonly CatalogoEscolarDbContext _dbContext;

        public CalificacionController(CatalogoEscolarDbContext dbContext) {
            _dbContext = dbContext;
        }

        //Get: api/Calificacion
        [ApiKey]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Calificacion>>> GetCalificaciones([FromHeader(Name = "X-API-Key")] string apiKey) {
            if (_dbContext.Calificacion == null) {
                return NotFound();
            }
            return await _dbContext.Calificacion.ToListAsync();
        }

        //Get: api/Calificacion/{id}
        [ApiKey]
        [HttpGet("{id}")]
        public async Task<ActionResult<Calificacion>> GetCalificacion([FromHeader(Name = "X-API-Key")] string apiKey,int id)
        {
            if (_dbContext.Calificacion == null)
            {
                return NotFound();
            }

            var calificacion = await _dbContext.Calificacion.FindAsync(id);

            if (calificacion == null) {
                return NotFound();
            }

            return calificacion;
        }

        //POST: api/Calificacion
        [ApiKey]
        [HttpPost]
        public async Task<ActionResult<Calificacion>> PostCalificacion([FromHeader(Name = "X-API-Key")] string apiKey,Calificacion calificacion)
        {
            _dbContext.Calificacion.Add(calificacion);
            await _dbContext.SaveChangesAsync();
            var calificacionGuardado = await _dbContext.Calificacion.FindAsync(calificacion.ID);
            return calificacionGuardado;
        }

        //PUT: api/Calificacion/{id}
        [ApiKey]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutCalificacion([FromHeader(Name = "X-API-Key")] string apiKey,int id, Calificacion calificacion)
        {
            if (id != calificacion.ID) {
                return BadRequest();
            }

            _dbContext.Entry(calificacion).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                if (!CalificacionExists(id))
                {
                    return NotFound();
                }
                else {
                    throw;
                }
            }

            return NoContent();
        }

        //DELETE: api/Calificacion/{id}
        [ApiKey]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCalificacion([FromHeader(Name = "X-API-Key")] string apiKey,int id)
        {
            if (_dbContext.Calificacion == null) {
                return NotFound();
            }

            var calificacion = await _dbContext.Calificacion.FindAsync(id);
            if (calificacion == null) {
                return NotFound();
            }

            _dbContext.Calificacion.Remove(calificacion);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

            private bool CalificacionExists(long id) { 
            return (_dbContext.Calificacion?.Any(e=> e.ID == id)).GetValueOrDefault();
        }
    }
}
