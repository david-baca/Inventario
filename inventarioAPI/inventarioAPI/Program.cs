using System;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Domain.Dto;
using Microsoft.EntityFrameworkCore;
using inventarioAPI.Services.IServices;
using inventarioAPI.Services.Services;
using static inventarioAPI.Context.Aplication_DB_Context;
using Org.BouncyCastle.Utilities.Net;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configurar la configuración de la aplicación
        builder.Configuration.AddJsonFile("appsettings.json");

        // Registrar servicios en el contenedor
        builder.Services.AddControllersWithViews();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: "MyCors", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            });
        });

        builder.Services.AddDbContext<AplicationdbContext>(options =>
        {
            options.UseMySQL(builder.Configuration.GetConnectionString("conexion"));
        });

        builder.Services.AddTransient<IInit, Init>();
        builder.Services.AddTransient<IRol, RolServices>();
        builder.Services.AddTransient<ICatalogo, CatalogoService>();
        builder.Services.AddTransient<IArea, AreaServices>();
        builder.Services.AddTransient<IFuente, FuenteServices>();
        builder.Services.AddTransient<IProvedor, ProvedorServices>();
        builder.Services.AddTransient<ICategoria, CategoriaServices>();
        builder.Services.AddTransient<IResponsable, ResponsableServices>();
        builder.Services.AddTransient<IUsuario, UsuarioServices>();
        builder.Services.AddTransient<IArticulo, ArticuloServices>();
        builder.Services.AddTransient<IHistorial, HistorialServices>();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Crear un scope de servicio para resolver IInit
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            try
            {
                var init = services.GetRequiredService<IInit>();
                await init.BDAsync();
                await init.RootAsync();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n******************** ERROR ******************");
                Console.WriteLine("No se logró conectarse al administrador MySQL");
                Console.WriteLine("***********************************************");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Edite el appsettings.json para cambiar la conexion\n");
                Console.ResetColor();
                Console.WriteLine("Presione cualquier letra para salir...");
                Console.Read();
                return;
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPROYECTO INVENTERIO 2023\n");
            Console.ResetColor();
        }

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseCors("MyCors");

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.Run();
    }
}