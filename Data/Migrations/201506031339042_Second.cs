namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fixture",
                c => new
                    {
                        LeagueId = c.Int(nullable: false),
                        TotalGames = c.Int(nullable: false),
                        SpecialGame = c.Int(),
                    })
                .PrimaryKey(t => t.LeagueId)
                .ForeignKey("dbo.League", t => t.LeagueId)
                .Index(t => t.LeagueId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fixture", "LeagueId", "dbo.League");
            DropIndex("dbo.Fixture", new[] { "LeagueId" });
            DropTable("dbo.Fixture");
        }
    }
}
