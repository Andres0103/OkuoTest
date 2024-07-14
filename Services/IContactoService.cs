using System.Collections.Generic;
using System.Threading.Tasks;
using OkuoTest.Models;

namespace OkuoTest.Services
{
    public interface IContactoService
    {
        Task<IEnumerable<Contacto>> GetContactosByPlantaIdAsync(int plantaId);
        Task<Contacto> GetContactoByIdAsync(int id);
        Task<Contacto> CreateContactoAsync(Contacto contacto);
        Task<Contacto> UpdateContactoAsync(int id, Contacto contacto);
        Task<bool> DeleteContactoAsync(int id);
    }
}
