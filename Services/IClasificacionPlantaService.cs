using OkuoTest.Models;
using System.Collections.Generic;

namespace OkuoTest.Services
{
    public interface IClasificacionPlantaService
    {
        List<ClasificacionPlanta> GetAll();
        ClasificacionPlanta GetById(int id);
        ClasificacionPlanta Create(ClasificacionPlanta clasificacionPlanta);
        ClasificacionPlanta Update(int id, ClasificacionPlanta clasificacionPlanta);
        bool Delete(int id);
    }
}
