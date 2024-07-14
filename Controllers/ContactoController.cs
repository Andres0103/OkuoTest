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
public class ContactoController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ContactoController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/empresa
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Contacto>>> GetContacto()
    {
        return await _context.Contactos.ToListAsync();
    }

    // GET: api/empresa/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Contacto>> GetContacto(int id)
    {
        var contacto = await _context.Contactos.FindAsync(id);

        if (contacto == null)
        {
            return NotFound();
        }

        return contacto;
    }

    // POST: api/empresa
    [HttpPost]
    public async Task<ActionResult<Contacto>> PostContacto(Contacto contacto)
    {
        _context.Contactos.Add(contacto);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetContacto), new { id = contacto.Id }, contacto);
    }

    // PUT: api/empresa/
    [HttpPut("{id}")]
    public async Task<IActionResult> PutContacto(int id, Contacto contacto)
    {
        if (id != contacto.Id)
        {
            return BadRequest("El ID proporcionado en la URL no coincide con el ID de la empresa.");
        }

        try
        {
            _context.Entry(contacto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ContactoExist(id))
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
    public async Task<IActionResult> DeleteContacto(int id)
    {
        var contacto = await _context.Contactos.FindAsync(id);
        if (contacto == null)
        {
            return NotFound();
        }

        _context.Contactos.Remove(contacto);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ContactoExist(int id)
    {
        return _context.Contactos.Any(e => e.Id == id);
    }
}
