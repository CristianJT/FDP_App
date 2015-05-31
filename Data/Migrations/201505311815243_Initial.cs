namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.League",
                c => new
                    {
                        LeagueId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Season = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        FinishDate = c.DateTime(nullable: false),
                        IsCurrent = c.Boolean(nullable: false),
                        Champion = c.String(),
                        RelegatedTeams = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LeagueId);
            
            CreateTable(
                "dbo.LeagueTeam",
                c => new
                    {
                        LeagueId = c.Int(nullable: false),
                        TeamId = c.Int(nullable: false),
                        Points = c.Int(nullable: false),
                        Played = c.Int(nullable: false),
                        Won = c.Int(nullable: false),
                        Draws = c.Int(nullable: false),
                        Lost = c.Int(nullable: false),
                        GoalsFor = c.Int(nullable: false),
                        GoalsAgainst = c.Int(nullable: false),
                        GoalDifference = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LeagueId, t.TeamId })
                .ForeignKey("dbo.Team", t => t.TeamId, cascadeDelete: true)
                .ForeignKey("dbo.League", t => t.LeagueId, cascadeDelete: true)
                .Index(t => t.LeagueId)
                .Index(t => t.TeamId);
            
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Stadium = c.String(),
                        City = c.String(),
                        IsTopDivision = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TeamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LeagueTeam", "LeagueId", "dbo.League");
            DropForeignKey("dbo.LeagueTeam", "TeamId", "dbo.Team");
            DropIndex("dbo.LeagueTeam", new[] { "TeamId" });
            DropIndex("dbo.LeagueTeam", new[] { "LeagueId" });
            DropTable("dbo.Team");
            DropTable("dbo.LeagueTeam");
            DropTable("dbo.League");
        }
    }
}
