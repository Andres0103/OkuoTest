using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OkuoTest.Models
{
    public class Planta
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Nit { get; set; }

        public string Ubicacion { get; set; }

        public string InformacionContacto { get; set; }

        public int EmpresaId { get; set; }

        public int TipoPlantaId { get; set; } // Definir explícitamente la clave foránea

        public TipoPlanta? Tipo { get; set; }

        public int ClasificacionPlantaId { get; set; } // Definir explícitamente la clave foránea

        public ClasificacionPlanta? Clasificacion { get; set; }

        public Empresa? Empresa { get; set; }

        // Colección de Contactos
        public ICollection<Contacto>? Contactos { get; set; }
    }
}
