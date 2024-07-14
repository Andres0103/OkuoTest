using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OkuoTest.Data;
using OkuoTest.Models;
using OkuoTest.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OkuoTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantaController : ControllerBase
    {
        private readonly IPlantaService _plantaService;

        private readonly ApplicationDbContext _context;
        public PlantaController(IPlantaService plantaService, ApplicationDbContext context)
        {
            _plantaService = plantaService;
            _context = context;
        }

        // GET: api/planta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Planta>>> GetPlantas()
        {
            var plantas = await _plantaService.GetAllPlantasAsync();
            return Ok(plantas);
        }

        // GET: api/planta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Planta>> GetPlanta(int id)
        {
            var planta = await _plantaService.GetPlantaByIdAsync(id);
            if (planta == null)
            {
                return NotFound();
            }
            return Ok(planta);
        }

        // POST: api/planta
        [HttpPost]
        public async Task<ActionResult<Planta>> PostPlanta(Planta planta)
        {
            var nuevaPlanta = await _plantaService.CreatePlantaAsync(planta);
            return CreatedAtAction(nameof(GetPlanta), new { id = nuevaPlanta.Id }, nuevaPlanta);
        }

        // PUT: api/planta/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlanta(int id, Planta planta)
        {
            if (id != planta.Id)
            {
                return BadRequest();
            }

            var plantaActualizada = await _plantaService.UpdatePlantaAsync(id, planta);
            if (plantaActualizada == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/planta/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlanta(int id)
        {
            var result = await _plantaService.DeletePlantaAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
