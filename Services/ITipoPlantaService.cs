using OkuoTest.Models;

namespace OkuoTest.Services;
public interface ITipoPlantaService
{
    Task<IEnumerable<TipoPlanta>> GetAllTipoPlantasAsync();
    Task<TipoPlanta> GetTipoPlantasByIdAsync(int tipoPlantasId);
    Task<TipoPlanta> CreateTipoPlantasaAsync(TipoPlanta tipoPlanta);
    Task<TipoPlanta> UpdateTipoPlantasAsync(int tipoPlantasId, TipoPlanta tipoPlantaActualizada);
    Task<bool> DeleteTipoPlantasaAsync(int tipoPlantasId);
}
