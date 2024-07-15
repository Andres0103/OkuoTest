namespace OkuoTest.Models;
public class Contacto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Cargo { get; set; }
    public string Telefono { get; set; }

    // Clave foránea y navegación a Planta
    public int PlantaId { get; set; }
    public Planta? Planta { get; set; }
}
