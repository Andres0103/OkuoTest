using OkuoTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OkuoTest.Services;
public class ClasificacionPlantaService : IClasificacionPlantaService
{
    private readonly List<ClasificacionPlanta> _clasificaciones;
    private int _nextId = 1;
    public ClasificacionPlantaService()
    {
        _clasificaciones = new List<ClasificacionPlanta>();
    }
    public List<ClasificacionPlanta> GetAll()
    {
        return _clasificaciones;
    }
    public ClasificacionPlanta GetById(int id)
    {
        return _clasificaciones.FirstOrDefault(c => c.Id == id);
    }
    public ClasificacionPlanta Create(ClasificacionPlanta clasificacionPlanta)
    {
        clasificacionPlanta.Id = _nextId++;
        _clasificaciones.Add(clasificacionPlanta);
        return clasificacionPlanta;
    }
    public ClasificacionPlanta Update(int id, ClasificacionPlanta clasificacionPlanta)
    {
        var existingClasificacion = _clasificaciones.FirstOrDefault(c => c.Id == id);
        if (existingClasificacion != null)
        {
            existingClasificacion.Nombre = clasificacionPlanta.Nombre;
        }
        return existingClasificacion;
    }
    public bool Delete(int id)
    {
        var clasificacionToRemove = _clasificaciones.FirstOrDefault(c => c.Id == id);
        if (clasificacionToRemove != null)
        {
            _clasificaciones.Remove(clasificacionToRemove);
            return true;
        }
        return false;
    }
}
