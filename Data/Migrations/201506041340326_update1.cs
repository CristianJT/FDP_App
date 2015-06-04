namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Game", name: "FixtureId", newName: "LeagueId");
            RenameIndex(table: "dbo.Game", name: "IX_FixtureId", newName: "IX_LeagueId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Game", name: "IX_LeagueId", newName: "IX_FixtureId");
            RenameColumn(table: "dbo.Game", name: "LeagueId", newName: "FixtureId");
        }
    }
}
