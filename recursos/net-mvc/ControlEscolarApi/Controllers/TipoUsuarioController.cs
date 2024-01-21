using ControlEscolarApi.Authorization;
using ControlEscolarApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControlEscolarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private readonly CatalogoEscolarDbContext _dbContext;

        public TipoUsuarioController(CatalogoEscolarDbContext dbContext) {
            _dbContext = dbContext;
        }

        //Get: api/TipoUsuario
        [ApiKey]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoUsuario>>> GetTiposUsuarios([FromHeader(Name = "X-API-Key")] string apiKey) {
            if (_dbContext.TipoUsuario == null) {
                return NotFound();
            }
            return await _dbContext.TipoUsuario.ToListAsync();
        }

        //Get: api/TipoUsuario/{id}
        [ApiKey]
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoUsuario>> GetTipoUsuario([FromHeader(Name = "X-API-Key")] string apiKey,int id)
        {
            if (_dbContext.TipoUsuario == null)
            {
                return NotFound();
            }

            var tipoUsuario = await _dbContext.TipoUsuario.FindAsync(id);

            if (tipoUsuario == null) {
                return NotFound();
            }

            return tipoUsuario;
        }

        //POST: api/TipoUsuario
        [ApiKey]
        [HttpPost]
        public async Task<ActionResult<TipoUsuario>> PostTipoUsuario([FromHeader(Name = "X-API-Key")] string apiKey,TipoUsuario tipoUsuario)
        {
            _dbContext.TipoUsuario.Add(tipoUsuario);
            await _dbContext.SaveChangesAsync();
            var tipoUsuarioGuardado = await _dbContext.TipoUsuario.FindAsync(tipoUsuario.ID);
            return tipoUsuarioGuardado;
        }

        //PUT: api/TipoUsuario/{id}
        [ApiKey]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutTipoUsuario([FromHeader(Name = "X-API-Key")] string apiKey,int id, TipoUsuario tipoUsuario)
        {
            if (id != tipoUsuario.ID) {
                return BadRequest();
            }

            _dbContext.Entry(tipoUsuario).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                if (!TipoUsuarioExists(id))
                {
                    return NotFound();
                }
                else {
                    throw;
                }
            }

            return NoContent();
        }

        //DELETE: api/TipoUsuario/{id}
        [ApiKey]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTipoUsuario([FromHeader(Name = "X-API-Key")] string apiKey,int id)
        {
            if (_dbContext.TipoUsuario == null) {
                return NotFound();
            }

            var tipoUsuario = await _dbContext.TipoUsuario.FindAsync(id);
            if (tipoUsuario == null) {
                return NotFound();
            }

            _dbContext.TipoUsuario.Remove(tipoUsuario);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

            private bool TipoUsuarioExists(long id) { 
            return (_dbContext.TipoUsuario?.Any(e=> e.ID == id)).GetValueOrDefault();
        }
    }
}
