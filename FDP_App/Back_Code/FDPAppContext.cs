using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace App.FDP
{
    public class FDPAppContext : DbContext
    {
        public FDPAppContext() : base("name = FDPAppContext")
        {
            Database.SetInitializer(new ContextInitializer());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<FDPAppContext, Migrations.Configuration>("FDPAppContext"));
        }

        public DbSet<League> Leagues { get; set; }
        public DbSet<LeagueTeam> LeagueTeams { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Entity<League>()
            //    .HasMany<LeagueTeam>(l => l.Teams)
            //    .WithRequired(lt => lt.League)
            //    .HasForeignKey(lt => lt.LeagueId);

            //modelBuilder.Entity<Team>()
            //    .HasMany<LeagueTeam>(t => t.Leagues)
            //    .WithRequired(lt => lt.Team)
            //    .HasForeignKey(lt => lt.TeamId);

            //modelBuilder.Entity<LeagueTeam>()
            //    .HasKey(lt => new { lt.LeagueId, lt.TeamId });

            //modelBuilder.Entity<Stadium>()
            //    .HasOptional(s => s.Team).WithMany()
            //    .HasForeignKey(s => s.TeamId);

            //modelBuilder.Entity<Team>()
            //    .HasRequired(t => t.Stadium).WithMany()
            //    .HasForeignKey(t => t.StadiumId);

            //modelBuilder.Entity<Fixture>()
            //    .HasMany<Game>(f => f.Games)
            //    .WithRequired(g => g.Fixture)
            //    .HasForeignKey(g => g.LeagueId);

            //modelBuilder.Entity<Game>()
            //    .HasMany<Match>(g => g.Matches)
            //    .WithRequired(m => m.Game)
            //    .HasForeignKey(m => m.GameId);

            //modelBuilder.Entity<Match>()
            //    .HasRequired(m => m.Game)
            //    .WithMany(g => g.Matches)
            //    .HasForeignKey(m => m.GameId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
