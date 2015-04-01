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
                new Torneo { Nombre = "Primera División 2015" },
                new Torneo { Nombre = "Final 2014" }
            });

            context.Equipos.AddOrUpdate(new Equipo[] {
                new Equipo { Nombre = "Independiente", Estadio = "Libertadores de América", Ubicacion = "Avellaneda"},
                new Equipo { Nombre = "River Plate", Estadio = "Antonio Vespucio Liberti", Ubicacion = "Nuñez"},
                new Equipo { Nombre = "Boca Juniors", Estadio = "Alberto J. Armando", Ubicacion = "La Boca"},
                new Equipo { Nombre = "Racing", Estadio = "Presidente Perón", Ubicacion = "Avellaneda"},
                new Equipo { Nombre = "San Lorenzo", Estadio = "Pedro Bidegain", Ubicacion = "Bajo Flores"},
                new Equipo { Nombre = "Huracan", Estadio = "Tomás Adolfo Ducó", Ubicacion = "Parque Patricios"},
            });
            
        }
    }
}
