using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Models
{
    public class LaboratorioContext : IdentityDbContext<Users>
    {
        public LaboratorioContext()
        {
        }

        public LaboratorioContext(DbContextOptions<LaboratorioContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=Laboratorio;User Id=sa;Password=1234;");
            }
        }
        
        public DbSet<Prediccion> Prediccion { get; set; }
        public DbSet<Resultado> Resultado { get; set; }
        public DbSet<Partido> Partido { get; set; }
        public DbSet<Campeonato> Campeonato { get; set; }
        public DbSet<Penca> Penca { get; set; }
        public DbSet<Publica> Publica { get; set; }
        public DbSet<Privada> Privada { get; set; }
        public DbSet<Equipo> Equipo { get; set; }

        

    }
}
