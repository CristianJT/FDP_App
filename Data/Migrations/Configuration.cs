namespace Data.Migrations
{
    using Entities.Models;
    using System;
    using System.Data.Entity.Migrations;


    internal sealed class Configuration : DbMigrationsConfiguration<Data.FDPAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.FDPAppContext context)
        {
            context.Leagues.AddOrUpdate(new League[] {
                new League { LeagueId = Guid.NewGuid(), Name = "Transici�n", Season = 2014, StartDate = DateTime.Now, FinishDate = DateTime.Now, IsCurrent = false, Champion = null, RelegatedTeams = 0  }
            });

            context.Teams.AddOrUpdate(new Team[] {
                new Team { TeamId = Guid.NewGuid(), Name = "Independiente", Stadium = "Libertadores de Am�rica", City = "Avellaneda(BsAs)", IsTopDivision = true },
                new Team { TeamId = Guid.NewGuid(), Name = "River Plate", Stadium = "Antonio Vespucio Liberti", City = "Nu�ez(CapFed)", IsTopDivision = true }
            });
        }
    }
}
