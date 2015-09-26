namespace FDP_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LeagueId = c.Int(nullable: false),
                        GameNumber = c.Int(nullable: false),
                        IsSpecialGame = c.Boolean(),
                        State = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.League", t => t.LeagueId, cascadeDelete: true)
                .Index(t => t.LeagueId);
            
            CreateTable(
                "dbo.League",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Season = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        FinishDate = c.DateTime(nullable: false),
                        IsCurrent = c.Boolean(nullable: false),
                        Champion = c.String(),
                        RelegatedTeams = c.Int(),
                        TotalGames = c.Int(nullable: false),
                        TotalTeams = c.Int(nullable: false),
                        SpecialGame = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .ForeignKey("dbo.League", t => t.LeagueId, cascadeDelete: true)
                .ForeignKey("dbo.Team", t => t.TeamId, cascadeDelete: true)
                .Index(t => t.LeagueId)
                .Index(t => t.TeamId);
            
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        StadiumId = c.Int(nullable: false),
                        Name = c.String(),
                        Location = c.String(),
                        IsTopDivision = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stadium", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Stadium",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeamId = c.Int(nullable: false),
                        Name = c.String(),
                        Location = c.String(),
                        Size = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Match",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameId = c.Int(nullable: false),
                        StadiumId = c.Int(),
                        MatchDate = c.DateTime(),
                        HomeTeamId = c.Int(),
                        AwayTeamId = c.Int(),
                        HomeResult = c.Int(),
                        AwayResult = c.Int(),
                        State = c.Int(nullable: false),
                        PlayedMinutes = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Team", t => t.AwayTeamId)
                .ForeignKey("dbo.Game", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.Team", t => t.HomeTeamId)
                .ForeignKey("dbo.Stadium", t => t.StadiumId)
                .Index(t => t.GameId)
                .Index(t => t.StadiumId)
                .Index(t => t.HomeTeamId)
                .Index(t => t.AwayTeamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Team", "Id", "dbo.Stadium");
            DropForeignKey("dbo.Match", "StadiumId", "dbo.Stadium");
            DropForeignKey("dbo.Match", "HomeTeamId", "dbo.Team");
            DropForeignKey("dbo.Match", "GameId", "dbo.Game");
            DropForeignKey("dbo.Match", "AwayTeamId", "dbo.Team");
            DropForeignKey("dbo.LeagueTeam", "TeamId", "dbo.Team");
            DropForeignKey("dbo.LeagueTeam", "LeagueId", "dbo.League");
            DropForeignKey("dbo.Game", "LeagueId", "dbo.League");
            DropIndex("dbo.Match", new[] { "AwayTeamId" });
            DropIndex("dbo.Match", new[] { "HomeTeamId" });
            DropIndex("dbo.Match", new[] { "StadiumId" });
            DropIndex("dbo.Match", new[] { "GameId" });
            DropIndex("dbo.Team", new[] { "Id" });
            DropIndex("dbo.LeagueTeam", new[] { "TeamId" });
            DropIndex("dbo.LeagueTeam", new[] { "LeagueId" });
            DropIndex("dbo.Game", new[] { "LeagueId" });
            DropTable("dbo.Match");
            DropTable("dbo.Stadium");
            DropTable("dbo.Team");
            DropTable("dbo.LeagueTeam");
            DropTable("dbo.League");
            DropTable("dbo.Game");
        }
    }
}
