using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OkuoTest.Data;
using OkuoTest.Models;
using OkuoTest.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OkuoTest.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClasificacionPlantaController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IClasificacionPlantaService _clasificacionPlantaService;
    public ClasificacionPlantaController(IClasificacionPlantaService clasificacionPlantaService, ApplicationDbContext context)
    {
        _clasificacionPlantaService = clasificacionPlantaService;
        _context = context;
    }

    // GET: api/clasificacionplanta
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClasificacionPlanta>>> GetAll()
    {
        return await _context.ClasificacionPlanta.ToListAsync();
    }

    // GET: api/clasificacionplanta
    [HttpGet("{id}")]
    public async Task<ActionResult<ClasificacionPlanta>> GetClasificacionById(int id)
    {
        var clasificacion = await _context.ClasificacionPlanta.FindAsync(id);
        if (clasificacion == null)
        {
            return NotFound();
        }
        return Ok(clasificacion);
    }

    // POST: api/clasificacionplanta
    [HttpPost]
    public async Task<ActionResult<ClasificacionPlanta>> CreateClasificacion(ClasificacionPlanta clasificacionPlanta)
    {
        _context.ClasificacionPlanta.Add(clasificacionPlanta);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetClasificacionById), new { id = clasificacionPlanta.Id }, clasificacionPlanta);
    }


    // PUT: api/clasificacionplanta
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ClasificacionPlanta clasificacionPlanta)
    {
        if (id != clasificacionPlanta.Id)
        {
            return BadRequest("El ID proporcionado en la URL no coincide con el ID de la clasificación.");
        }

        try
        {
            _context.Entry(clasificacionPlanta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ClasificacionPlantaExists(id))
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

    // DELETE: api/clasificacionplanta
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var clasificacion = await _context.ClasificacionPlanta.FindAsync(id);
        if (clasificacion == null)
        {
            return NotFound();
        }

        _context.ClasificacionPlanta.Remove(clasificacion);
        await _context.SaveChangesAsync();
        return NoContent();
    }
    private bool ClasificacionPlantaExists(int id)
    {
        return _context.ClasificacionPlanta.Any(e => e.Id == id);
    }
}
