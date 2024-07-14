namespace OkuoTest.Models;
public class TipoPlanta
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public List<Planta> Plantas { get; set; } = new List<Planta>();

}
