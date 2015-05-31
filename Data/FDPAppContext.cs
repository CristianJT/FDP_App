using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Entities.Models;

namespace Data
{
    public class FDPAppContext : DbContext
    {
        public FDPAppContext() : base("name = FDPAppContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FDPAppContext, Migrations.Configuration>("FDPAppContext"));
        }

        public DbSet<League> Leagues { get; set; }
        public DbSet<LeagueTeam> LeagueTeams { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<League>()
                .HasMany<LeagueTeam>(l => l.Teams)
                .WithRequired(lt => lt.League)
                .HasForeignKey(lt => lt.LeagueId);

            modelBuilder.Entity<Team>()
                .HasMany<LeagueTeam>(t => t.Leagues)
                .WithRequired(lt => lt.Team)
                .HasForeignKey(lt => lt.TeamId);

            modelBuilder.Entity<LeagueTeam>()
                .HasKey(lt => new { lt.LeagueId, lt.TeamId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
