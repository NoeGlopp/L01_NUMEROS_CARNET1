using Microsoft.;
using L01_NUMEROS_CARNET.Models; // Ajusta el namespace según la ubicación de tus modelos

namespace L01_NUMEROS_CARNET.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet para cada tabla de la base de datos
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Publicacion> Publicaciones { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Calificacion> Calificaciones { get; set; }
    }
}
