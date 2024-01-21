using ControlEscolarApi.Authorization;
using ControlEscolarApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControlEscolarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UbicacionController : ControllerBase
    {
        private readonly CatalogoEscolarDbContext _dbContext;

        public UbicacionController(CatalogoEscolarDbContext dbContext) {
            _dbContext = dbContext;
        }

        //Get: api/Ubicacion
        [ApiKey]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ubicacion>>> GetUbicaciones([FromHeader(Name = "X-API-Key")] string apiKey) {
            if (_dbContext.Ubicacion == null) {
                return NotFound();
            }
            return await _dbContext.Ubicacion.ToListAsync();
        }

        //Get: api/Ubicacion/{id}
        [ApiKey]
        [HttpGet("{id}")]
        public async Task<ActionResult<Ubicacion>> GetUbicacion([FromHeader(Name = "X-API-Key")] string apiKey,int id)
        {
            if (_dbContext.Ubicacion == null)
            {
                return NotFound();
            }

            var ubicacion = await _dbContext.Ubicacion.FindAsync(id);

            if (ubicacion == null) {
                return NotFound();
            }

            return ubicacion;
        }

        //POST: api/Ubicacion
        [ApiKey]
        [HttpPost]
        public async Task<ActionResult<Ubicacion>> PostUbicacion([FromHeader(Name = "X-API-Key")] string apiKey,Ubicacion ubicacion)
        {
            _dbContext.Ubicacion.Add(ubicacion);
            await _dbContext.SaveChangesAsync();
            var ubicacionGuardado = await _dbContext.Ubicacion.FindAsync(ubicacion.ID);
            return ubicacionGuardado;
        }

        //PUT: api/Ubicacion/{id}
        [ApiKey]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutUbicacion([FromHeader(Name = "X-API-Key")] string apiKey,int id, Ubicacion ubicacion)
        {
            if (id != ubicacion.ID) {
                return BadRequest();
            }

            _dbContext.Entry(ubicacion).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                if (!UbicacionExists(id))
                {
                    return NotFound();
                }
                else {
                    throw;
                }
            }

            return NoContent();
        }

        //DELETE: api/Ubicacion/{id}
        [ApiKey]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUbicacion([FromHeader(Name = "X-API-Key")] string apiKey,int id)
        {
            if (_dbContext.Ubicacion == null) {
                return NotFound();
            }

            var ubicacion = await _dbContext.Ubicacion.FindAsync(id);
            if (ubicacion == null) {
                return NotFound();
            }

            _dbContext.Ubicacion.Remove(ubicacion);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

            private bool UbicacionExists(long id) { 
            return (_dbContext.Ubicacion?.Any(e=> e.ID == id)).GetValueOrDefault();
        }
    }
}
