using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OkuoTest.Services;
using OkuoTest.Data;

namespace OkuoTest;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();

        // Configuración de Swagger/OpenAPI
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "OkuoTest API", Version = "v1" });
        });

        // Configuración de DbContext
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Inyección de dependencias para los servicios
        builder.Services.AddScoped<IPlantaService, PlantaService>();
        builder.Services.AddScoped<IContactoService, ContactoService>();
        builder.Services.AddScoped<IEmpresaService, EmpresaService>();
        builder.Services.AddScoped<ITipoPlantaService, TipoPlantaService>();
        builder.Services.AddScoped<IClasificacionPlantaService, ClasificacionPlantaService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "OkuoTest API V1");
            });
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
