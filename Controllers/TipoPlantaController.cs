using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OkuoTest.Data;
using OkuoTest.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OkuoTest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TipoPlantaController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TipoPlantaController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/empresa
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TipoPlanta>>> GetEmpresas()
    {
        return await _context.TipoPlanta.ToListAsync();
    }

    // GET: api/empresa/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TipoPlanta>> GetTipoEmpresa(int id)
    {
        var tipoPlanta = await _context.TipoPlanta.FindAsync(id);

        if (tipoPlanta == null)
        {
            return NotFound();
        }

        return tipoPlanta;
    }

    // POST: api/empresa
    [HttpPost]
    public async Task<ActionResult<TipoPlanta>> PostTipoPlanta(TipoPlanta tipoPlanta)
    {
        _context.TipoPlanta.Add(tipoPlanta);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTipoEmpresa), new { id = tipoPlanta.Id }, tipoPlanta);
    }

    // PUT: api/empresa/
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTipoPlanta(int id, TipoPlanta tipoPlanta)
    {
        if (id != tipoPlanta.Id)
        {
            return BadRequest("El ID proporcionado en la URL no coincide con el ID de la empresa.");
        }

        try
        {
            _context.Entry(tipoPlanta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TipoPlantaExist(id))
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


    // DELETE: api/empresa/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTipoPlanta(int id)
    {
        var tipoPlanta = await _context.TipoPlanta.FindAsync(id);
        if (tipoPlanta == null)
        {
            return NotFound();
        }

        _context.TipoPlanta.Remove(tipoPlanta);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TipoPlantaExist(int id)
    {
        return _context.TipoPlanta.Any(e => e.Id == id);
    }
}
