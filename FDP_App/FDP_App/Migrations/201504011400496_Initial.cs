namespace FDP_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Equipo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Estadio = c.String(),
                        Ubicacion = c.String(),
                        TorneoId = c.Int(),
                        Puntos = c.Int(nullable: false),
                        Jugados = c.Int(nullable: false),
                        Ganados = c.Int(nullable: false),
                        Empatados = c.Int(nullable: false),
                        Perdidos = c.Int(nullable: false),
                        GolesFavor = c.Int(nullable: false),
                        GolesContra = c.Int(nullable: false),
                        Diferencia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Torneo", t => t.TorneoId)
                .Index(t => t.TorneoId);
            
            CreateTable(
                "dbo.Torneo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Fecha",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        TorneoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Torneo", t => t.TorneoId, cascadeDelete: true)
                .Index(t => t.TorneoId);
            
            CreateTable(
                "dbo.Partido",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocalId = c.Int(nullable: false),
                        VisitanteId = c.Int(nullable: false),
                        FechaId = c.Int(nullable: false),
                        FechaHora = c.DateTime(nullable: false),
                        Estadio = c.String(),
                        Clasico = c.Boolean(nullable: false),
                        LocalRes = c.Int(nullable: false),
                        VisitanteRes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fecha", t => t.FechaId, cascadeDelete: true)
                .Index(t => t.FechaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fecha", "TorneoId", "dbo.Torneo");
            DropForeignKey("dbo.Partido", "FechaId", "dbo.Fecha");
            DropForeignKey("dbo.Equipo", "TorneoId", "dbo.Torneo");
            DropIndex("dbo.Partido", new[] { "FechaId" });
            DropIndex("dbo.Fecha", new[] { "TorneoId" });
            DropIndex("dbo.Equipo", new[] { "TorneoId" });
            DropTable("dbo.Partido");
            DropTable("dbo.Fecha");
            DropTable("dbo.Torneo");
            DropTable("dbo.Equipo");
        }
    }
}
