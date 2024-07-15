using Microsoft.EntityFrameworkCore;
using OkuoTest.Models;

namespace OkuoTest.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Planta> Plantas { get; set; }
    public DbSet<Contacto> Contactos { get; set; }
    public DbSet<Empresa> Empresas { get; set; }
    public DbSet<TipoPlanta> TipoPlanta { get; set; }
    public DbSet<ClasificacionPlanta> ClasificacionPlanta { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Relación entre Empresa y Planta
        modelBuilder.Entity<Empresa>()
            .HasMany(e => e.Plantas)
            .WithOne(p => p.Empresa)
            .HasForeignKey(p => p.EmpresaId);

        // Configuración de la relación uno a muchos entre Planta y Contacto
        modelBuilder.Entity<Planta>()
            .HasMany(p => p.Contactos)
            .WithOne(c => c.Planta)
            .HasForeignKey(c => c.PlantaId);

        // Configuración de la relación uno a muchos entre TipoPlanta y Planta
        modelBuilder.Entity<TipoPlanta>()
            .HasMany(tp => tp.Plantas)
            .WithOne(p => p.Tipo)
            .HasForeignKey(p => p.TipoPlantaId); // Usar TipoPlantaId como clave foránea

        // Configuración de la relación uno a muchos entre ClasificacionPlanta y Planta
        modelBuilder.Entity<ClasificacionPlanta>()
            .HasMany(cp => cp.Plantas)
            .WithOne(p => p.Clasificacion)
            .HasForeignKey(p => p.ClasificacionPlantaId); // Usar ClasificacionPlantaId como clave foránea
    }
}
