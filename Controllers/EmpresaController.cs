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
public class EmpresaController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public EmpresaController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/empresa
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Empresa>>> GetEmpresas()
    {
        return await _context.Empresas.ToListAsync();
    }

    // GET: api/empresa/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Empresa>> GetEmpresa(int id)
    {
        var empresa = await _context.Empresas.FindAsync(id);

        if (empresa == null)
        {
            return NotFound();
        }

        return empresa;
    }

    // POST: api/empresa
    [HttpPost]
    public async Task<ActionResult<Empresa>> PostEmpresa(Empresa empresa)
    {
        _context.Empresas.Add(empresa);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetEmpresa), new { id = empresa.Id }, empresa);
    }

    // PUT: api/empresa/
    [HttpPut("{id}")]
    public async Task<IActionResult> PutEmpresa(int id, Empresa empresa)
    {
        if (id != empresa.Id)
        {
            return BadRequest("El ID proporcionado en la URL no coincide con el ID de la empresa.");
        }

        try
        {
            _context.Entry(empresa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EmpresaExists(id))
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
    public async Task<IActionResult> DeleteEmpresa(int id)
    {
        var empresa = await _context.Empresas.FindAsync(id);
        if (empresa == null)
        {
            return NotFound();
        }

        _context.Empresas.Remove(empresa);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool EmpresaExists(int id)
    {
        return _context.Empresas.Any(e => e.Id == id);
    }
}
