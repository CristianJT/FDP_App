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
                new League { LeagueId = 1, Name = "Primera División", Season = 2014, StartDate = DateTime.Parse("2014-08-08"), FinishDate = DateTime.Parse("2014-12-14"), IsCurrent = false, Champion = "Racing Club", RelegatedTeams = 0  },
                new League { LeagueId = 2, Name = "Final", Season = 2014, StartDate = DateTime.Parse("2014-02-07"), FinishDate = DateTime.Parse("2014-05-19"), IsCurrent = false, Champion = "River Plate", RelegatedTeams = 2  }
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
                new LeagueTeam { LeagueId = 1, TeamId = 1, Points = 33, Played = 19, Won = 10, Draws = 3, Lost = 6, GoalsFor = 31, GoalsAgainst = 29, GoalDifference = 2 },
                new LeagueTeam { LeagueId = 1, TeamId = 2, Points = 39, Played = 19, Won = 11, Draws = 6, Lost = 2, GoalsFor = 34, GoalsAgainst = 13, GoalDifference = 21 },
                new LeagueTeam { LeagueId = 1, TeamId = 3, Points = 31, Played = 19, Won = 9, Draws = 4, Lost = 6, GoalsFor = 25, GoalsAgainst = 23, GoalDifference = 2 },
                new LeagueTeam { LeagueId = 1, TeamId = 4, Points = 41, Played = 19, Won = 13, Draws = 2, Lost = 4, GoalsFor = 30, GoalsAgainst = 16, GoalDifference = 14 },
                new LeagueTeam { LeagueId = 1, TeamId = 5, Points = 26, Played = 19, Won = 8, Draws = 2, Lost = 9, GoalsFor = 26, GoalsAgainst = 22, GoalDifference = 4 },
                new LeagueTeam { LeagueId = 2, TeamId = 2, Points = 37, Played = 19, Won = 11, Draws = 4, Lost = 4, GoalsFor = 28, GoalsAgainst = 15, GoalDifference = 13 },
                new LeagueTeam { LeagueId = 2, TeamId = 3, Points = 32, Played = 19, Won = 9, Draws = 5, Lost = 5, GoalsFor = 25, GoalsAgainst = 15, GoalDifference =  10}
            });
        }
    }
}
