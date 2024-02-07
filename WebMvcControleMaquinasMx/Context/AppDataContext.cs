using Microsoft.EntityFrameworkCore;
using WebMvc_Domain.Domain;
using WebMvcControleMaquinasMx.MappingData;

namespace WebMvcControleMaquinasMx.Context
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        { }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }
    }
}
