using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace App.FDP
{
    public class ContextInitializer : DropCreateDatabaseAlways<FDPAppContext>
    {
        protected override void Seed(FDPAppContext context)
        {
            context.Leagues.AddOrUpdate(new League[] {
                new League { Id = 1, Name = "Final", Season = 2014, StartDate = DateTime.Parse("2014-02-07"), FinishDate = DateTime.Parse("2014-05-19"), IsCurrent = false, Champion = "River Plate", RelegatedTeams = 2  }
            });

            context.Teams.AddOrUpdate(new Team[] {
                new Team { Id = 1, StadiumId = 1, Name = "Independiente", Location = "Avellaneda(BsAs)", IsTopDivision = true },
                new Team { Id = 2, StadiumId = 2, Name = "River Plate", Location = "Nuñez(CapFed)", IsTopDivision = true },
                new Team { Id = 3, StadiumId = 3, Name = "Boca Juniors", Location = "La Boca(CapFed)", IsTopDivision = true }
            });

            context.LeagueTeams.AddOrUpdate(new LeagueTeam[] {
                new LeagueTeam { LeagueId = 1, TeamId = 2, Points = 37, Played = 19, Won = 11, Draws = 4, Lost = 4, GoalsFor = 28, GoalsAgainst = 15, GoalDifference = 13 },
                new LeagueTeam { LeagueId = 1, TeamId = 3, Points = 32, Played = 19, Won = 9, Draws = 5, Lost = 5, GoalsFor = 25, GoalsAgainst = 15, GoalDifference =  10}
            });

            context.Stadiums.AddOrUpdate(new Stadium[] {
                new Stadium { Id = 1, TeamId = 1, Name = "Libertadores de América", Location = "Avellaneda(BsAs)" },
                new Stadium { Id = 2, TeamId = 2, Name = "Antonio Vespucio Liberti", Location = "Nuñez(CapFed)" },
                new Stadium { Id = 3, TeamId = 3, Name = "Alberto J. Armando", Location = "La Boca(CapFed)" },
                new Stadium { Id = 4, Name = "Ciudad de La Plata", Location = "La Plata(BsAs)" }
            });
        }
    }
}
