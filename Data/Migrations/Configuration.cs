namespace Data.Migrations
{
    using Entities.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.FDPAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.FDPAppContext context)
        {
            context.Leagues.AddOrUpdate(new League[] {
                new League { LeagueId = 1, Name = "Transición", Season = 2014, StartDate = DateTime.Now, FinishDate = DateTime.Now, IsCurrent = false, Champion = "Racing Club", RelegatedTeams = 0  },
                new League { LeagueId = 2, Name = "Final", Season = 2014, StartDate = DateTime.Now, FinishDate = DateTime.Now, IsCurrent = false, Champion = "River Plate", RelegatedTeams = 2  }
            });

            context.Teams.AddOrUpdate(new Team[] {
                new Team { TeamId = 1, Name = "Independiente", Stadium = "Libertadores de América", City = "Avellaneda(BsAs)", IsTopDivision = true },
                new Team { TeamId = 2, Name = "River Plate", Stadium = "Antonio Vespucio Liberti", City = "Nuñez(CapFed)", IsTopDivision = true },
                new Team { TeamId = 3, Name = "Boca Juniors", Stadium = "Alberto J. Armando", City = "La Boca(CapFed)", IsTopDivision = true },
                new Team { TeamId = 4, Name = "Racing Club", Stadium = "Presidente Perón", City = "Avellaneda(BsAs)", IsTopDivision = true },
                new Team { TeamId = 5, Name = "San Lorenzo", Stadium = "Pedro Bidegain", City = "Bajo Flores(CapFed)", IsTopDivision = true },
                new Team { TeamId = 6, Name = "Huracan", Stadium = "Tomás Adolfo Ducó", City = "Parque Patricios(CapFed)", IsTopDivision = true },
                new Team { TeamId = 7, Name = "Velez Sarsfield", Stadium = "José Amalfitani", City = "Liniers(CapFed)", IsTopDivision = true }
            });

            context.LeagueTeams.AddOrUpdate(new LeagueTeam[] {
                new LeagueTeam { LeagueId = 1, TeamId = 1 },
                new LeagueTeam { LeagueId = 1, TeamId = 2 },
                new LeagueTeam { LeagueId = 1, TeamId = 3 },
                new LeagueTeam { LeagueId = 1, TeamId = 4 },
                new LeagueTeam { LeagueId = 1, TeamId = 5 },
                new LeagueTeam { LeagueId = 2, TeamId = 2 },
                new LeagueTeam { LeagueId = 2, TeamId = 3 }
            });
        }
    }
}
