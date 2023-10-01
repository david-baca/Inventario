using Domain.Entity;
using inventarioAPI.Services.IServices;
using Microsoft.EntityFrameworkCore;
using static inventarioAPI.Context.Aplication_DB_Context;

namespace inventarioAPI.Services.Services
{
    public class Init : IInit
    {
        private readonly AplicationdbContext _context;

        public Init(AplicationdbContext context)
        {
            _context = context;
        }

        public async Task RootAsync()
        {
            var root = await _context.Usuarios.Where(x => x.PkUsuario==1).FirstOrDefaultAsync();
            var rol = await _context.Roles.Where(x => x.PkRol==1).FirstOrDefaultAsync();
            try
            {
                if (root == null && rol == null)
                {
                    rol = new Rol()
                    {
                        Nombre = "ROOT",
                        Estado = false
                    };
                    await _context.Roles.AddAsync(rol);

                    root = new Usuario()
                    {
                        Nombres = "Root",
                        Apellido_M = "Root",
                        Apellido_P = "Root",

                        N_Usuario = "Upqroo",
                        Contrseña = "Estancias*2023",
                        FkRol = 1,
                        Estado = true,
                    };
                    await _context.Usuarios.AddAsync(root);
                    await _context.SaveChangesAsync();
                }
            }
            catch {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("\n************************** ALERTA ************************");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Se ha eliminado el usuario ROOT del sistema, consulte el");
                Console.WriteLine("manual de usuario para restablecer los datos del sistema.\n");
                Console.ResetColor();
                
            }
        }

        public async Task BDAsync()
        {
            // Verifica si la base de datos existe
            bool databaseExists = await _context.Database.CanConnectAsync();

            if (!databaseExists)
            {// Si la base de datos no existe, crea la base de datos y migra las tablas
                await _context.Database.EnsureCreatedAsync();
                
            }
        }
    }
}
