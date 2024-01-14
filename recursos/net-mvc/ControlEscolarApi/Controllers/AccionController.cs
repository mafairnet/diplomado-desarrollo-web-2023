using ControlEscolarApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControlEscolarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccionController : ControllerBase
    {
        private readonly CatalogoEscolarDbContext _dbContext;

        public AccionController(CatalogoEscolarDbContext dbContext) {
            _dbContext = dbContext;
        }

        //Get: api/Accion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Accion>>> GetAccions() {
            if (_dbContext.Accion == null) {
                return NotFound();
            }
            return await _dbContext.Accion.ToListAsync();
        }

        //Get: api/Accion/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Accion>> GetAccion(int id)
        {
            if (_dbContext.Accion == null)
            {
                return NotFound();
            }

            var accion = await _dbContext.Accion.FindAsync(id);

            if (accion == null) {
                return NotFound();
            }

            return accion;
        }

        //POST: api/Accion
        [HttpPost]
        public async Task<ActionResult<Accion>> PostAccion(Accion accion)
        {
            _dbContext.Accion.Add(accion);
            await _dbContext.SaveChangesAsync();
            var accionGuardado = await _dbContext.Accion.FindAsync(accion.ID);
            return accionGuardado;
        }

        //PUT: api/Accion/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAccion(int id, Accion accion)
        {
            if (id != accion.ID) {
                return BadRequest();
            }

            _dbContext.Entry(accion).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                if (!AccionExists(id))
                {
                    return NotFound();
                }
                else {
                    throw;
                }
            }

            return NoContent();
        }

        //DELETE: api/Accion/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAccion(int id)
        {
            if (_dbContext.Accion == null) {
                return NotFound();
            }

            var accion = await _dbContext.Accion.FindAsync(id);
            if (accion == null) {
                return NotFound();
            }

            _dbContext.Accion.Remove(accion);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

            private bool AccionExists(long id) { 
            return (_dbContext.Accion?.Any(e=> e.ID == id)).GetValueOrDefault();
        }
    }
}
