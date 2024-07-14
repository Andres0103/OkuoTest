using OkuoTest.Models;
using System.Collections.Generic;

namespace OkuoTest.Services
{
    public interface ITipoPlantaService
    {
        List<TipoPlanta> GetAll();
        TipoPlanta GetById(int id);
        TipoPlanta Create(TipoPlanta tipoPlanta);
        TipoPlanta Update(int id, TipoPlanta tipoPlanta);
        bool Delete(int id);
    }
}
