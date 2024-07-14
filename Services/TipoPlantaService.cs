using OkuoTest.Data;
using OkuoTest.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OkuoTest.Services
{
    public class TipoPlantaService : ITipoPlantaService
    {
        private readonly ApplicationDbContext _context;

        public TipoPlantaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TipoPlanta>> GetAllTipoPlantasAsync()
        {
            return await _context.TipoPlanta.ToListAsync();
        }

        public async Task<TipoPlanta> GetTipoPlantasByIdAsync(int tipoPlantasId)
        {
            return await _context.TipoPlanta.FindAsync(tipoPlantasId);
        }

        public async Task<TipoPlanta> CreateTipoPlantasaAsync(TipoPlanta tipoPlanta)
        {
            _context.TipoPlanta.Add(tipoPlanta);
            await _context.SaveChangesAsync();
            return tipoPlanta;
        }

        public async Task<TipoPlanta> UpdateTipoPlantasAsync(int tipoPlantasId, TipoPlanta tipoPlantaActualizada)
        {
            var tipoPlanta = await _context.TipoPlanta.FindAsync(tipoPlantasId);
            if (tipoPlanta == null)
            {
                return null;
            }

            tipoPlanta.Nombre = tipoPlantaActualizada.Nombre;

            await _context.SaveChangesAsync();
            return tipoPlanta;
        }

        public async Task<bool> DeleteTipoPlantasaAsync(int tipoPlantasId)
        {
            var tipoPlanta = await _context.TipoPlanta.FindAsync(tipoPlantasId);
            if (tipoPlanta == null)
            {
                return false;
            }

            _context.TipoPlanta.Remove(tipoPlanta);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}