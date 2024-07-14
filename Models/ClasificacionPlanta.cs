namespace OkuoTest.Models
{
    public class ClasificacionPlanta
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }

        public List<Planta> Plantas { get; set; } = new List<Planta>();
    }
}
