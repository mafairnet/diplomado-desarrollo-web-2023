using ControlEscolarApi.Authorization;
using ControlEscolarApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControlEscolarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalidadController : ControllerBase
    {
        private readonly CatalogoEscolarDbContext _dbContext;

        public LocalidadController(CatalogoEscolarDbContext dbContext) {
            _dbContext = dbContext;
        }

        //Get: api/Localidad
        [ApiKey]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Localidad>>> GetLocalidades([FromHeader(Name = "X-API-Key")] string apiKey) {
            if (_dbContext.Localidad == null) {
                return NotFound();
            }
            return await _dbContext.Localidad.ToListAsync();
        }

        //Get: api/Localidad/{id}
        [ApiKey]
        [HttpGet("{id}")]
        public async Task<ActionResult<Localidad>> GetLocalidad([FromHeader(Name = "X-API-Key")] string apiKey,int id)
        {
            if (_dbContext.Localidad == null)
            {
                return NotFound();
            }

            var localidad = await _dbContext.Localidad.FindAsync(id);

            if (localidad == null) {
                return NotFound();
            }

            return localidad;
        }

        //POST: api/Localidad
        [ApiKey]
        [HttpPost]
        public async Task<ActionResult<Localidad>> PostLocalidad([FromHeader(Name = "X-API-Key")] string apiKey,Localidad localidad)
        {
            _dbContext.Localidad.Add(localidad);
            await _dbContext.SaveChangesAsync();
            var localidadGuardado = await _dbContext.Localidad.FindAsync(localidad.ID);
            return localidadGuardado;
        }

        //PUT: api/Localidad/{id}
        [ApiKey]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutLocalidad([FromHeader(Name = "X-API-Key")] string apiKey,int id, Localidad localidad)
        {
            if (id != localidad.ID) {
                return BadRequest();
            }

            _dbContext.Entry(localidad).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                if (!LocalidadExists(id))
                {
                    return NotFound();
                }
                else {
                    throw;
                }
            }

            return NoContent();
        }

        //DELETE: api/Localidad/{id}
        [ApiKey]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLocalidad([FromHeader(Name = "X-API-Key")] string apiKey,int id)
        {
            if (_dbContext.Localidad == null) {
                return NotFound();
            }

            var localidad = await _dbContext.Localidad.FindAsync(id);
            if (localidad == null) {
                return NotFound();
            }

            _dbContext.Localidad.Remove(localidad);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

            private bool LocalidadExists(long id) { 
            return (_dbContext.Localidad?.Any(e=> e.ID == id)).GetValueOrDefault();
        }
    }
}
