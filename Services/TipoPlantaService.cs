using OkuoTest.Models;
using System.Collections.Generic;
using System.Linq;

namespace OkuoTest.Services
{
    public class TipoPlantaServiceImpl : ITipoPlantaService
    {
        private readonly List<TipoPlanta> _tiposPlantas;
        private int _nextId = 1;

        public TipoPlantaServiceImpl()
        {
            _tiposPlantas = new List<TipoPlanta>();
        }

        public List<TipoPlanta> GetAll()
        {
            return _tiposPlantas;
        }

        public TipoPlanta GetById(int id)
        {
            return _tiposPlantas.FirstOrDefault(tp => tp.Id == id);
        }

        public TipoPlanta Create(TipoPlanta tipoPlanta)
        {
            tipoPlanta.Id = _nextId++;
            _tiposPlantas.Add(tipoPlanta);
            return tipoPlanta;
        }

        public TipoPlanta Update(int id, TipoPlanta tipoPlanta)
        {
            var existingTipoPlanta = _tiposPlantas.FirstOrDefault(tp => tp.Id == id);
            if (existingTipoPlanta != null)
            {
                existingTipoPlanta.Nombre = tipoPlanta.Nombre;
            }
            return existingTipoPlanta;
        }

        public bool Delete(int id)
        {
            var tipoPlantaToRemove = _tiposPlantas.FirstOrDefault(tp => tp.Id == id);
            if (tipoPlantaToRemove != null)
            {
                _tiposPlantas.Remove(tipoPlantaToRemove);
                return true;
            }
            return false;
        }
    }
}
