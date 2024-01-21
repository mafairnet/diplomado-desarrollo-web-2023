using ControlEscolarApi.Authorization;
using ControlEscolarApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControlEscolarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly CatalogoEscolarDbContext _dbContext;

        public UsuarioController(CatalogoEscolarDbContext dbContext) {
            _dbContext = dbContext;
        }

        //Get: api/Usuario
        [ApiKey]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios([FromHeader(Name = "X-API-Key")] string apiKey) {
            if (_dbContext.Usuario == null) {
                return NotFound();
            }
            return await _dbContext.Usuario.ToListAsync();
        }

        //Get: api/Usuario/{id}
        [ApiKey]
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario([FromHeader(Name = "X-API-Key")] string apiKey,int id)
        {
            if (_dbContext.Usuario == null)
            {
                return NotFound();
            }

            var usuario = await _dbContext.Usuario.FindAsync(id);

            if (usuario == null) {
                return NotFound();
            }

            return usuario;
        }

        //POST: api/Usuario
        [ApiKey]
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario([FromHeader(Name = "X-API-Key")] string apiKey,Usuario usuario)
        {
            _dbContext.Usuario.Add(usuario);
            await _dbContext.SaveChangesAsync();
            var usuarioGuardado = await _dbContext.Usuario.FindAsync(usuario.ID);
            return usuarioGuardado;
        }

        //PUT: api/Usuario/{id}
        [ApiKey]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutUsuario([FromHeader(Name = "X-API-Key")] string apiKey,int id, Usuario usuario)
        {
            if (id != usuario.ID) {
                return BadRequest();
            }

            _dbContext.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else {
                    throw;
                }
            }

            return NoContent();
        }

        //DELETE: api/Usuario/{id}
        [ApiKey]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUsuario([FromHeader(Name = "X-API-Key")] string apiKey,int id)
        {
            if (_dbContext.Usuario == null) {
                return NotFound();
            }

            var usuario = await _dbContext.Usuario.FindAsync(id);
            if (usuario == null) {
                return NotFound();
            }

            _dbContext.Usuario.Remove(usuario);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

            private bool UsuarioExists(long id) { 
            return (_dbContext.Usuario?.Any(e=> e.ID == id)).GetValueOrDefault();
        }
    }
}
