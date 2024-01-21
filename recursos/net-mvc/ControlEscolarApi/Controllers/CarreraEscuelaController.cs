using ControlEscolarApi.Authorization;
using ControlEscolarApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControlEscolarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarreraEscuelaController : ControllerBase
    {
        private readonly CatalogoEscolarDbContext _dbContext;

        public CarreraEscuelaController(CatalogoEscolarDbContext dbContext) {
            _dbContext = dbContext;
        }

        //Get: api/CarreraEscuela
        [ApiKey]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarreraEscuela>>> GetCarrerasEscuela([FromHeader(Name = "X-API-Key")] string apiKey) {
            if (_dbContext.CarreraEscuela == null) {
                return NotFound();
            }
            return await _dbContext.CarreraEscuela.ToListAsync();
        }

        //Get: api/CarreraEscuela/{id}
        [ApiKey]
        [HttpGet("{id}")]
        public async Task<ActionResult<CarreraEscuela>> GetCarreraEscuela([FromHeader(Name = "X-API-Key")] string apiKey,string id)
        {
            String[] idArray = id.Split('_');

            int idCarrera = int.Parse(idArray[0]);
            int idEscuela = int.Parse(idArray[1]);


            if (_dbContext.CarreraEscuela == null)
            {
                return NotFound();
            }

            var carreraEscuela = await _dbContext.CarreraEscuela.FirstOrDefaultAsync(e => e.IdEscuela == idEscuela && e.IdCarrera == idCarrera);

            if (carreraEscuela == null) {
                return NotFound();
            }

            return carreraEscuela;
        }

        //POST: api/CarreraEscuela
        [ApiKey]
        [HttpPost]
        public async Task<ActionResult<CarreraEscuela>> PostCarreraEscuela([FromHeader(Name = "X-API-Key")] string apiKey,CarreraEscuela carreraEscuela)
        {
            _dbContext.CarreraEscuela.Add(carreraEscuela);
            await _dbContext.SaveChangesAsync();
            var carreraEscuelaGuardado = await _dbContext.CarreraEscuela.FirstOrDefaultAsync(e => e.IdEscuela == carreraEscuela.IdEscuela && e.IdCarrera == carreraEscuela.IdCarrera);
            return carreraEscuelaGuardado;
        }

        //DELETE: api/CarreraEscuela/{id}
        [ApiKey]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCarreraEscuela([FromHeader(Name = "X-API-Key")] string apiKey,string id)
        {
            String[] idArray = id.Split('_');

            int idCarrera = int.Parse(idArray[0]);
            int idEscuela = int.Parse(idArray[1]);

            if (_dbContext.CarreraEscuela == null) {
                return NotFound();
            }

            var carreraEscuela = await _dbContext.CarreraEscuela.FirstOrDefaultAsync(e => e.IdEscuela == idEscuela && e.IdCarrera == idCarrera);
            if (carreraEscuela == null) {
                return NotFound();
            }

            _dbContext.CarreraEscuela.Remove(carreraEscuela);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

    }
}
