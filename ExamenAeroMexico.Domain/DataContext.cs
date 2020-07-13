using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ExamenAeroMexico.Domain
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public DbSet<ExamenAeroMexico.Domain.Vuelo> Vueloes { get; set; }
        public DbSet<ExamenAeroMexico.Domain.Pasajero> Pasajeroes { get; set; }
    }
}
