using ControlEscolarApi.Authorization;
using ControlEscolarApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControlEscolarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalleController : ControllerBase
    {
        private readonly CatalogoEscolarDbContext _dbContext;

        public CalleController(CatalogoEscolarDbContext dbContext) {
            _dbContext = dbContext;
        }

        //Get: api/Calle
        [ApiKey]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Calle>>> GetCalles([FromHeader(Name = "X-API-Key")] string apiKey) {
            if (_dbContext.Calle == null) {
                return NotFound();
            }
            return await _dbContext.Calle.ToListAsync();
        }

        //Get: api/Calle/{id}
        [ApiKey]
        [HttpGet("{id}")]
        public async Task<ActionResult<Calle>> GetCalle([FromHeader(Name = "X-API-Key")] string apiKey,int id)
        {
            if (_dbContext.Calle == null)
            {
                return NotFound();
            }

            var calle = await _dbContext.Calle.FindAsync(id);

            if (calle == null) {
                return NotFound();
            }

            return calle;
        }

        //POST: api/Calle
        [ApiKey]
        [HttpPost]
        public async Task<ActionResult<Calle>> PostCalle([FromHeader(Name = "X-API-Key")] string apiKey,Calle calle)
        {
            _dbContext.Calle.Add(calle);
            await _dbContext.SaveChangesAsync();
            var calleGuardado = await _dbContext.Calle.FindAsync(calle.ID);
            return calleGuardado;
        }

        //PUT: api/Calle/{id}
        [ApiKey]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutCalle([FromHeader(Name = "X-API-Key")] string apiKey,int id, Calle calle)
        {
            if (id != calle.ID) {
                return BadRequest();
            }

            _dbContext.Entry(calle).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                if (!CalleExists(id))
                {
                    return NotFound();
                }
                else {
                    throw;
                }
            }

            return NoContent();
        }

        //DELETE: api/Calle/{id}
        [ApiKey]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCalle([FromHeader(Name = "X-API-Key")] string apiKey,int id)
        {
            if (_dbContext.Calle == null) {
                return NotFound();
            }

            var calle = await _dbContext.Calle.FindAsync(id);
            if (calle == null) {
                return NotFound();
            }

            _dbContext.Calle.Remove(calle);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

            private bool CalleExists(long id) { 
            return (_dbContext.Calle?.Any(e=> e.ID == id)).GetValueOrDefault();
        }
    }
}
