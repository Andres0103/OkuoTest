using OkuoTest.Data;
using OkuoTest.Models;
using Microsoft.EntityFrameworkCore;

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
        return await _context.Plantas.ToListAsync();
    }
    public async Task<Planta> GetPlantaByIdAsync(int plantaId)
    {
        return await _context.Plantas.FindAsync(plantaId);
    }
    public async Task<Planta> CreatePlantaAsync(Planta planta)
    {
        _context.Plantas.Add(planta);
        await _context.SaveChangesAsync();
        return planta;
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
        planta.EmpresaId = plantaActualizada.EmpresaId;
        planta.TipoPlantaId = plantaActualizada.TipoPlantaId;
        planta.ClasificacionPlantaId = plantaActualizada.ClasificacionPlantaId;
        
        await _context.SaveChangesAsync();
        return planta;
    }
    public async Task<bool> DeletePlantaAsync(int plantasId)
    {
        var planta = await _context.Plantas.FindAsync(plantasId);
        if (planta == null)
        {
            return false;
        }

        _context.Plantas.Remove(planta);
        await _context.SaveChangesAsync();
        return true;
    }
}