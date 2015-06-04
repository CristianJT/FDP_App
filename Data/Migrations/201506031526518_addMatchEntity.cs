namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMatchEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Match",
                c => new
                    {
                        MatchId = c.Int(nullable: false, identity: true),
                        GameId = c.Int(nullable: false),
                        HomeTeam = c.String(),
                        AwayTeam = c.String(),
                        HomeResult = c.Int(nullable: false),
                        AwayResult = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MatchId)
                .ForeignKey("dbo.Game", t => t.GameId, cascadeDelete: true)
                .Index(t => t.GameId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Match", "GameId", "dbo.Game");
            DropIndex("dbo.Match", new[] { "GameId" });
            DropTable("dbo.Match");
        }
    }
}
