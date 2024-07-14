using OkuoTest.Models;
using OkuoTest.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OkuoTest.Services;
public class PlantaService : IPlantaService
{
    private readonly ApplicationDbContext _context;

    public PlantaService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Planta>> GetAllPlantasAsync()
    {
        return await _context.Plantas.Include(p => p.Contactos).ToListAsync();
    }

    public async Task<Planta> GetPlantaByIdAsync(int plantaId)
    {
        return await _context.Plantas.Include(p => p.Contactos).FirstOrDefaultAsync(p => p.Id == plantaId);
    }

    public async Task<Planta> CreatePlantaAsync(Planta nuevaPlanta)
    {
        _context.Plantas.Add(nuevaPlanta);
        await _context.SaveChangesAsync();
        return nuevaPlanta;
    }

    public async Task<Planta> UpdatePlantaAsync(int plantaId, Planta plantaActualizada)
    {
        var planta = await _context.Plantas.FindAsync(plantaId);
        if (planta == null)
        {
            return null;
        }

        planta.Nombre = plantaActualizada.Nombre;
        planta.Nit = plantaActualizada.Nit;
        planta.Ubicacion = plantaActualizada.Ubicacion;
        planta.InformacionContacto = plantaActualizada.InformacionContacto;
        planta.Tipo = plantaActualizada.Tipo;
        planta.Clasificacion = plantaActualizada.Clasificacion;

        await _context.SaveChangesAsync();
        return planta;
    }

    public async Task<bool> DeletePlantaAsync(int plantaId)
    {
        var planta = await _context.Plantas.FindAsync(plantaId);
        if (planta == null)
        {
            return false;
        }

        _context.Plantas.Remove(planta);
        await _context.SaveChangesAsync();
        return true;
    }
}
