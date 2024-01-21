using ControlEscolarApi.Authorization;
using ControlEscolarApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControlEscolarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly CatalogoEscolarDbContext _dbContext;

        public EstadoController(CatalogoEscolarDbContext dbContext) {
            _dbContext = dbContext;
        }

        //Get: api/Estado
        [ApiKey]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estado>>> GetEstados([FromHeader(Name = "X-API-Key")] string apiKey) {
            if (_dbContext.Estado == null) {
                return NotFound();
            }
            return await _dbContext.Estado.ToListAsync();
        }

        //Get: api/Estado/{id}
        [ApiKey]
        [HttpGet("{id}")]
        public async Task<ActionResult<Estado>> GetEstado([FromHeader(Name = "X-API-Key")] string apiKey,int id)
        {
            if (_dbContext.Estado == null)
            {
                return NotFound();
            }

            var estado = await _dbContext.Estado.FindAsync(id);

            if (estado == null) {
                return NotFound();
            }

            return estado;
        }

        //POST: api/Estado
        [ApiKey]
        [HttpPost]
        public async Task<ActionResult<Estado>> PostEstado([FromHeader(Name = "X-API-Key")] string apiKey,Estado estado)
        {
            _dbContext.Estado.Add(estado);
            await _dbContext.SaveChangesAsync();
            var estadoGuardado = await _dbContext.Estado.FindAsync(estado.ID);
            return estadoGuardado;
        }

        //PUT: api/Estado/{id}
        [ApiKey]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutEstado([FromHeader(Name = "X-API-Key")] string apiKey,int id, Estado estado)
        {
            if (id != estado.ID) {
                return BadRequest();
            }

            _dbContext.Entry(estado).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                if (!EstadoExists(id))
                {
                    return NotFound();
                }
                else {
                    throw;
                }
            }

            return NoContent();
        }

        //DELETE: api/Estado/{id}
        [ApiKey]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEstado([FromHeader(Name = "X-API-Key")] string apiKey,int id)
        {
            if (_dbContext.Estado == null) {
                return NotFound();
            }

            var estado = await _dbContext.Estado.FindAsync(id);
            if (estado == null) {
                return NotFound();
            }

            _dbContext.Estado.Remove(estado);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

            private bool EstadoExists(long id) { 
            return (_dbContext.Estado?.Any(e=> e.ID == id)).GetValueOrDefault();
        }
    }
}
