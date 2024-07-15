namespace OkuoTest.Models;
public class Empresa
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string NIT { get; set; }

    // Navegación
    public ICollection<Planta> Plantas { get; set; }
}
