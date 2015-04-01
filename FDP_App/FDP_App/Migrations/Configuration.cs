namespace FDP_App.Migrations
{
    using FDP_App.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FDP_App.DAL.FDP_AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FDP_App.DAL.FDP_AppContext context)
        {
            context.Torneos.AddOrUpdate(new Torneo[] {
                new Torneo { Nombre = "Primera Divisi�n 2015" },
                new Torneo { Nombre = "Final 2014" }
            });

            context.Equipos.AddOrUpdate(new Equipo[] {
                new Equipo { Nombre = "Independiente", Estadio = "Libertadores de Am�rica", Ubicacion = "Avellaneda"},
                new Equipo { Nombre = "River Plate", Estadio = "Antonio Vespucio Liberti", Ubicacion = "Nu�ez"},
                new Equipo { Nombre = "Boca Juniors", Estadio = "Alberto J. Armando", Ubicacion = "La Boca"},
                new Equipo { Nombre = "Racing", Estadio = "Presidente Per�n", Ubicacion = "Avellaneda"},
                new Equipo { Nombre = "San Lorenzo", Estadio = "Pedro Bidegain", Ubicacion = "Bajo Flores"},
                new Equipo { Nombre = "Huracan", Estadio = "Tom�s Adolfo Duc�", Ubicacion = "Parque Patricios"},
            });
            
        }
    }
}
