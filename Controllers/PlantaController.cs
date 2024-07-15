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
            return await _context.Plantas.ToListAsync();
        }

        // GET: api/planta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Planta>> GetPlanta(int id)
        {
            var planta = await _context.Plantas.FindAsync(id);

            if (planta == null)
            {
                return NotFound();
            }
            return Ok(planta);
        }

        // POST: api/planta
        [HttpPost]
        public async Task<ActionResult<Planta>> CreatePlantaAsync(Planta planta)
        {
            _context.Plantas.Add(planta);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPlanta), new { id = planta.Id }, planta);
        }

        // PUT: api/planta/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlanta(int id, Planta planta)
        {

            if (id != planta.Id)
            {
                return BadRequest("El ID proporcionado no coincide con algun registro.");
            }

            try
            {
                _context.Entry(planta).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantaExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // DELETE: api/planta/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlanta(int id)
        {
            var planta = await _context.Plantas.FindAsync(id);
            if (planta == null)
            {
                return NotFound();
            }

            _context.Plantas.Remove(planta);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool PlantaExist(int id)
        {
            return _context.Plantas.Any(e => e.Id == id);
        }
    }
}
