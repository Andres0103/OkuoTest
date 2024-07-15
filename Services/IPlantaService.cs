using OkuoTest.Models;

namespace OkuoTest.Services;
public interface IPlantaService
{
    Task<IEnumerable<Planta>> GetAllPlantasAsync();
    Task<Planta> GetPlantaByIdAsync(int plantaId);
    Task<Planta> CreatePlantaAsync(Planta nuevaPlanta);
    Task<Planta> UpdatePlantaAsync(int plantaId, Planta plantaActualizada);
    Task<bool> DeletePlantaAsync(int plantaId);
}
