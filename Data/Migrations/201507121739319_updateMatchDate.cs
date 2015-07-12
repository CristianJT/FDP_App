namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMatchDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Match", "MatchDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Match", "MatchDate", c => c.DateTime());
        }
    }
}
