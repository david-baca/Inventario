

using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace inventarioAPI.Context
{
    public class Aplication_DB_Context
    {
        public class AplicationdbContext : DbContext
        {
            public AplicationdbContext()
            {
            }

            public AplicationdbContext(DbContextOptions<AplicationdbContext> options) : base(options)
            {
                //public DbSet<Usuario> Usuario { get; set; }
            }
           
            public DbSet<Rol> Roles { get; set; }

            public DbSet<Catalogo> Catalogos { get; set; }

            public DbSet<Area> Areas { get; set; }

            public DbSet<Fuente> Fuentes { get; set;}

            public DbSet<Provedor> Provedores { get; set; }

            public DbSet<Categoria> Categorias { get; set; }

            public DbSet<Responsable> Responsables { get; set; }

            public DbSet<Usuario> Usuarios { get; set; }

            public DbSet<Articulo> Articulos { get; set; }
            public DbSet<Historial> Historials { get; set; }
            public DbSet<Accion> Accion { get; set; }
        }
    }
}
