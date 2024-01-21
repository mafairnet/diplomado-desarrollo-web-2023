using ControlEscolarApi.Authorization;
using ControlEscolarApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControlEscolarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarreraController : ControllerBase
    {
        private readonly CatalogoEscolarDbContext _dbContext;

        public CarreraController(CatalogoEscolarDbContext dbContext) {
            _dbContext = dbContext;
        }

        //Get: api/Carrera
        [ApiKey]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carrera>>> GetCarreras([FromHeader(Name = "X-API-Key")] string apiKey) {
            if (_dbContext.Carrera == null) {
                return NotFound();
            }
            return await _dbContext.Carrera.ToListAsync();
        }

        //Get: api/Carrera/{id}
        [ApiKey]
        [HttpGet("{id}")]
        public async Task<ActionResult<Carrera>> GetCarrera([FromHeader(Name = "X-API-Key")] string apiKey,int id)
        {
            if (_dbContext.Carrera == null)
            {
                return NotFound();
            }

            var carrera = await _dbContext.Carrera.FindAsync(id);

            if (carrera == null) {
                return NotFound();
            }

            return carrera;
        }

        //POST: api/Carrera
        [ApiKey]
        [HttpPost]
        public async Task<ActionResult<Carrera>> PostCarrera([FromHeader(Name = "X-API-Key")] string apiKey,Carrera carrera)
        {
            _dbContext.Carrera.Add(carrera);
            await _dbContext.SaveChangesAsync();
            var carreraGuardado = await _dbContext.Carrera.FindAsync(carrera.ID);
            return carreraGuardado;
        }

        //PUT: api/Carrera/{id}
        [ApiKey]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutCarrera([FromHeader(Name = "X-API-Key")] string apiKey,int id, Carrera carrera)
        {
            if (id != carrera.ID) {
                return BadRequest();
            }

            _dbContext.Entry(carrera).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                if (!CarreraExists(id))
                {
                    return NotFound();
                }
                else {
                    throw;
                }
            }

            return NoContent();
        }

        //DELETE: api/Carrera/{id}
        [ApiKey]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCarrera([FromHeader(Name = "X-API-Key")] string apiKey,int id)
        {
            if (_dbContext.Carrera == null) {
                return NotFound();
            }

            var carrera = await _dbContext.Carrera.FindAsync(id);
            if (carrera == null) {
                return NotFound();
            }

            _dbContext.Carrera.Remove(carrera);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

            private bool CarreraExists(long id) { 
            return (_dbContext.Carrera?.Any(e=> e.ID == id)).GetValueOrDefault();
        }
    }
}
