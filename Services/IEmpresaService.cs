using OkuoTest.Models;

namespace OkuoTest.Services;
public interface IEmpresaService
{
    Task<IEnumerable<Empresa>> GetAllEmpresasAsync();
    Task<Empresa> GetEmpresaByIdAsync(int empresaId);
    Task<Empresa> CreateEmpresaAsync(Empresa nuevaEmpresa);
    Task<Empresa> UpdateEmpresaAsync(int empresaId, Empresa empresaActualizada);
    Task<bool> DeleteEmpresaAsync(int empresaId);
}
