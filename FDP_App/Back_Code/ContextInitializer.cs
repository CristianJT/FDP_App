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
                new League { LeagueId = 1, Name = "Final", Season = 2014, StartDate = DateTime.Parse("2014-02-07"), FinishDate = DateTime.Parse("2014-05-19"), IsCurrent = false, Champion = "River Plate", RelegatedTeams = 2  }
            });

            context.Teams.AddOrUpdate(new Team[] {
                new Team { TeamId = 1, Name = "Independiente", Stadium = "Libertadores de América", City = "Avellaneda(BsAs)", IsTopDivision = false },
                new Team { TeamId = 2, Name = "River Plate", Stadium = "Antonio Vespucio Liberti", City = "Nuñez(CapFed)", IsTopDivision = true },
                new Team { TeamId = 3, Name = "Boca Juniors", Stadium = "Alberto J. Armando", City = "La Boca(CapFed)", IsTopDivision = true },
                new Team { TeamId = 4, Name = "Racing Club", Stadium = "Presidente Perón", City = "Avellaneda(BsAs)", IsTopDivision = true },
                new Team { TeamId = 5, Name = "San Lorenzo", Stadium = "Pedro Bidegain", City = "Bajo Flores(CapFed)", IsTopDivision = true },
                new Team { TeamId = 6, Name = "Huracan", Stadium = "Tomás Adolfo Ducó", City = "Parque Patricios(CapFed)", IsTopDivision = false },
                new Team { TeamId = 7, Name = "Velez Sarsfield", Stadium = "José Amalfitani", City = "Liniers(CapFed)", IsTopDivision = true },
                new Team { TeamId = 8, Name = "Estudiantes(LP)", Stadium = "Ciudad de La Plata", City = "La Plata(BsAs)", IsTopDivision = true },
                new Team { TeamId = 9, Name = "Gimnasia(LP)", Stadium = "Juan Carmelo Zerillo", City = "La Plata(BsAs)", IsTopDivision = true },
                new Team { TeamId = 10, Name = "Newell's Old Boys", Stadium = "Marcelo A. Bielsa «El Coloso»", City = "Rosario(SF)", IsTopDivision = true },
                new Team { TeamId = 11, Name = "Rosario Central", Stadium = "Gigante de Arroyito", City = "Rosario(SF)", IsTopDivision = true },
                new Team { TeamId = 12, Name = "Colon", Stadium = "Brigadier López", City = "Santa Fe", IsTopDivision = false },
                new Team { TeamId = 13, Name = "Godoy Cruz", Stadium = "Feliciano Gambarte", City = "Mendoza", IsTopDivision = true },
                new Team { TeamId = 14, Name = "Lanus", Stadium = "Ciudad de Lanús - Néstor Díaz Pérez", City = "Lanus(BsAs)", IsTopDivision = true },
                new Team { TeamId = 15, Name = "Olimpo", Stadium = "Roberto Natalio Carminatti", City = "Bahía Blanca(BsAs)", IsTopDivision = true },
                new Team { TeamId = 16, Name = "Tigre", Stadium = "José Dellagiovanna", City = "San Fernando(BsAs)", IsTopDivision = true },
                new Team { TeamId = 17, Name = "Arsenal", Stadium = "Julio Humberto Grondona", City = "Avellaneda(BsAs)", IsTopDivision = true },
                new Team { TeamId = 18, Name = "Belgrano", Stadium = "Julio César Villagra", City = "Córdoba", IsTopDivision = true },
                new Team { TeamId = 19, Name = "Atlético de Rafaela", Stadium = "Nuevo Monumental", City = "Rafaela(SF)", IsTopDivision = true },
                new Team { TeamId = 20, Name = "Banfield", Stadium = "Florencio Sola", City = "Lomas de Zamora(BsAs)", IsTopDivision = false },
                new Team { TeamId = 21, Name = "Defensa y Justicia", Stadium = "Norberto Tomaghello", City = "Florencio Varela(BsAs)", IsTopDivision = false },
                new Team { TeamId = 22, Name = "Quilmes", Stadium = "Centenario", City = "Quilmes(BsAs)", IsTopDivision = true }
            });

            context.LeagueTeams.AddOrUpdate(new LeagueTeam[] {
                new LeagueTeam { LeagueId = 1, TeamId = 2, Points = 37, Played = 19, Won = 11, Draws = 4, Lost = 4, GoalsFor = 28, GoalsAgainst = 15, GoalDifference = 13 },
                new LeagueTeam { LeagueId = 1, TeamId = 3, Points = 32, Played = 19, Won = 9, Draws = 5, Lost = 5, GoalsFor = 25, GoalsAgainst = 15, GoalDifference =  10}
            });

            context.Fixture.AddOrUpdate(new Fixture[] {
                new Fixture { LeagueId = 1, TotalGames = 19, SpecialGame = 0 }
            });
        }
    }
}
