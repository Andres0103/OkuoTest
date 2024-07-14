using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using OkuoTest.Services;
using OkuoTest.Models;
using OkuoTest.Data;

namespace OkuoTest.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactoController : ControllerBase
{
    private readonly IContactoService _contactoService;

    private readonly ApplicationDbContext _context;

    public ContactoController(IContactoService contactoService, ApplicationDbContext context)
    {
        _contactoService = contactoService;
        _context = context;
    }

    // GET: api/contacto/planta/{plantaId}
    [HttpGet("planta/{plantaId}")]
    public async Task<ActionResult<IEnumerable<Contacto>>> GetContactosByPlanta(int plantaId)
    {
        var contactos = await _contactoService.GetContactosByPlantaIdAsync(plantaId);
        return Ok(contactos);
    }

    // GET: api/contacto/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Contacto>> GetContacto(int id)
    {
        var contacto = await _contactoService.GetContactoByIdAsync(id);
        if (contacto == null)
        {
            return NotFound();
        }
        return Ok(contacto);
    }

    // POST: api/contacto
    [HttpPost]
    public async Task<ActionResult<Contacto>> PostContacto(Contacto contacto)
    {
        var nuevoContacto = await _contactoService.CreateContactoAsync(contacto);
        return CreatedAtAction(nameof(GetContacto), new { id = nuevoContacto.Id }, nuevoContacto);
    }

    // PUT: api/contacto/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutContacto(int id, Contacto contacto)
    {
        if (id != contacto.Id)
        {
            return BadRequest();
        }

        var contactoActualizado = await _contactoService.UpdateContactoAsync(id, contacto);
        if (contactoActualizado == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    // DELETE: api/contacto/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContacto(int id)
    {
        var result = await _contactoService.DeleteContactoAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
}
