namespace FDP_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSeasonField : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.League", "Season", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.League", "Season", c => c.Int(nullable: false));
        }
    }
}
