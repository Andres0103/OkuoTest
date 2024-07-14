using OkuoTest.Models;
using OkuoTest.Data;
using Microsoft.EntityFrameworkCore;

namespace OkuoTest.Services;
public class EmpresaService : IEmpresaService
{
    private readonly ApplicationDbContext _context;

    public EmpresaService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Empresa>> GetAllEmpresasAsync()
    {
        return await _context.Empresas.Include(e => e.Plantas).ToListAsync();
    }

    public async Task<Empresa> GetEmpresaByIdAsync(int empresaId)
    {
        return await _context.Empresas.Include(e => e.Plantas).FirstOrDefaultAsync(e => e.Id == empresaId);
    }

    public async Task<Empresa> CreateEmpresaAsync(Empresa nuevaEmpresa)
    {
        _context.Empresas.Add(nuevaEmpresa);
        await _context.SaveChangesAsync();
        return nuevaEmpresa;
    }

    public async Task<Empresa> UpdateEmpresaAsync(int empresaId, Empresa empresaActualizada)
    {
        var empresa = await _context.Empresas.FindAsync(empresaId);
        if (empresa == null)
        {
            return null;
        }

        empresa.Nombre = empresaActualizada.Nombre;
        empresa.NIT = empresaActualizada.NIT;

        await _context.SaveChangesAsync();
        return empresa;
    }

    public async Task<bool> DeleteEmpresaAsync(int empresaId)
    {
        var empresa = await _context.Empresas.FindAsync(empresaId);
        if (empresa == null)
        {
            return false;
        }

        _context.Empresas.Remove(empresa);
        await _context.SaveChangesAsync();
        return true;
    }
}
