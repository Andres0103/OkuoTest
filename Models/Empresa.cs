namespace OkuoTest.Models;
public class Empresa
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string NIT { get; set; }

    // Navegación
    public List<Planta> Plantas { get; set; } = new List<Planta>();

}
