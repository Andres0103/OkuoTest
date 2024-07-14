using OkuoTest.Data;
using OkuoTest.Models;
using OkuoTest.Services;
using Microsoft.EntityFrameworkCore;
public class ContactoService : IContactoService
{
    private readonly ApplicationDbContext _context;

    public ContactoService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Contacto>> GetContactosByPlantaIdAsync(int plantaId)
    {
        return await _context.Contactos.Where(c => c.PlantaId == plantaId).ToListAsync();
    }

    public async Task<Contacto> GetContactoByIdAsync(int id)
    {
        return await _context.Contactos.Include(c => c.Planta).FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Contacto> CreateContactoAsync(Contacto contacto)
    {
        _context.Contactos.Add(contacto);
        await _context.SaveChangesAsync();
        return contacto;
    }

    public async Task<Contacto> UpdateContactoAsync(int id, Contacto contacto)
    {
        var existingContacto = await _context.Contactos.FindAsync(id);
        if (existingContacto == null) return null;

        existingContacto.Nombre = contacto.Nombre;
        existingContacto.Email = contacto.Email;
        existingContacto.Cargo = contacto.Cargo;
        existingContacto.Telefono = contacto.Telefono;
        existingContacto.PlantaId = contacto.PlantaId;

        await _context.SaveChangesAsync();
        return existingContacto;
    }

    public async Task<bool> DeleteContactoAsync(int id)
    {
        var contacto = await _context.Contactos.FindAsync(id);
        if (contacto == null) return false;

        _context.Contactos.Remove(contacto);
        await _context.SaveChangesAsync();
        return true;
    }
}
