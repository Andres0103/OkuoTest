using Microsoft.AspNetCore.Mvc;
using OkuoTest.Data;
using OkuoTest.Models;
using OkuoTest.Services;

namespace OkuoTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPlantaController : ControllerBase
    {
        private readonly TipoPlantaServiceImpl _tipoPlantaService;

        private readonly ApplicationDbContext _context;
        public TipoPlantaController(TipoPlantaServiceImpl tipoPlantaService, ApplicationDbContext context)
        {
            _tipoPlantaService = tipoPlantaService;
            _context = context;
        }

        // GET: api/TipoPlanta
        [HttpGet]
        public IActionResult Get()
        {
            var tiposPlantas = _tipoPlantaService.GetAll();
            return Ok(tiposPlantas);
        }

        // GET: api/TipoPlanta/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var tipoPlanta = _tipoPlantaService.GetById(id);
            if (tipoPlanta == null)
            {
                return NotFound();
            }
            return Ok(tipoPlanta);
        }

        // POST: api/TipoPlanta
        [HttpPost]
        public IActionResult Post([FromBody] TipoPlanta tipoPlanta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdTipoPlanta = _tipoPlantaService.Create(tipoPlanta);
            return CreatedAtAction(nameof(GetById), new { id = createdTipoPlanta.Id }, createdTipoPlanta);
        }

        // PUT: api/TipoPlanta/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TipoPlanta tipoPlanta)
        {
            if (id != tipoPlanta.Id)
            {
                return BadRequest("El ID proporcionado en la URL no coincide con el ID de la planta.");
            }

            var updatedTipoPlanta = _tipoPlantaService.Update(id, tipoPlanta);
            if (updatedTipoPlanta == null)
            {
                return NotFound();
            }
            return Ok(updatedTipoPlanta);
        }

        // DELETE: api/TipoPlanta/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _tipoPlantaService.Delete(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
