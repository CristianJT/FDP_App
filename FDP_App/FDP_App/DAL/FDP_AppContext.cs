using FDP_App.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FDP_App.DAL
{
    public class FDP_AppContext : DbContext
    {
        public FDP_AppContext() : base("FDP_AppContext")
        {
        }

        public DbSet<Torneo> Torneos { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Fecha> Fixture { get; set; }
        public DbSet<Partido> Partidos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Equipo>()
                .HasMany(a => a.Partidos)
                .WithRequired(a => a.Local).HasForeignKey(a => a.LocalId);

            modelBuilder.Entity<Equipo>()
                .HasMany(a => a.Partidos)
                .WithOptional(a => a.Visitante).HasForeignKey(a => a.VisitanteId);

            modelBuilder.Entity<Fecha>()
                .HasMany(a => a.Partidos)
                .WithRequired(a => a.Fecha).HasForeignKey(a => a.FechaId);

            modelBuilder.Entity<Torneo>()
                .HasMany(a => a.Equipos)
                .WithOptional(a => a.Torneo).HasForeignKey(a => a.TorneoId);

            modelBuilder.Entity<Torneo>()
                .HasMany(a => a.Fixture)
                .WithRequired(a => a.Torneo).HasForeignKey(a => a.TorneoId);

            base.OnModelCreating(modelBuilder);
        }

        public static FDP_AppContext Create()
        {
            return new FDP_AppContext();
        }
    }
}