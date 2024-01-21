using ControlEscolarApi.Authorization;
using ControlEscolarApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControlEscolarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : ControllerBase
    {
        private readonly CatalogoEscolarDbContext _dbContext;

        public PaisController(CatalogoEscolarDbContext dbContext) {
            _dbContext = dbContext;
        }

        //Get: api/Pais
        [ApiKey]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pais>>> GetPaises([FromHeader(Name = "X-API-Key")] string apiKey) {
            if (_dbContext.Pais == null) {
                return NotFound();
            }
            return await _dbContext.Pais.ToListAsync();
        }

        //Get: api/Pais/{id}
        [ApiKey]
        [HttpGet("{id}")]
        public async Task<ActionResult<Pais>> GetPais([FromHeader(Name = "X-API-Key")] string apiKey,int id)
        {
            if (_dbContext.Pais == null)
            {
                return NotFound();
            }

            var pais = await _dbContext.Pais.FindAsync(id);

            if (pais == null) {
                return NotFound();
            }

            return pais;
        }

        //POST: api/Pais
        [ApiKey]
        [HttpPost]
        public async Task<ActionResult<Pais>> PostPais([FromHeader(Name = "X-API-Key")] string apiKey,Pais pais)
        {
            _dbContext.Pais.Add(pais);
            await _dbContext.SaveChangesAsync();
            var paisGuardado = await _dbContext.Pais.FindAsync(pais.ID);
            return paisGuardado;
        }

        //PUT: api/Pais/{id}
        [ApiKey]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutPais([FromHeader(Name = "X-API-Key")] string apiKey,int id, Pais pais)
        {
            if (id != pais.ID) {
                return BadRequest();
            }

            _dbContext.Entry(pais).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                if (!PaisExists(id))
                {
                    return NotFound();
                }
                else {
                    throw;
                }
            }

            return NoContent();
        }

        //DELETE: api/Pais/{id}
        [ApiKey]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePais([FromHeader(Name = "X-API-Key")] string apiKey,int id)
        {
            if (_dbContext.Pais == null) {
                return NotFound();
            }

            var pais = await _dbContext.Pais.FindAsync(id);
            if (pais == null) {
                return NotFound();
            }

            _dbContext.Pais.Remove(pais);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

            private bool PaisExists(long id) { 
            return (_dbContext.Pais?.Any(e=> e.ID == id)).GetValueOrDefault();
        }
    }
}
