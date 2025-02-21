using Microsoft.EntityFrameworkCore;
using L01_NUMEROS_CARNET.Models; 

namespace L01_NUMEROS_CARNET.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Publicacion> Publicaciones { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Calificacion> Calificaciones { get; set; }
    }
}
