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
                new League { LeagueId = 1, Name = "Transición", Season = 2014, StartDate = DateTime.Now, FinishDate = DateTime.Now, IsCurrent = false, Champion = null, RelegatedTeams = 0  }
            });

            context.Teams.AddOrUpdate(new Team[] {
                new Team { TeamId = 1, Name = "Independiente", Stadium = "Libertadores de América", City = "Avellaneda(BsAs)", IsTopDivision = true },
                new Team { TeamId = 2, Name = "River Plate", Stadium = "Antonio Vespucio Liberti", City = "Nuñez(CapFed)", IsTopDivision = true }
            });
        }
    }
}
