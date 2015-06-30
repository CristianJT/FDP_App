namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMatch : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Match", "MatchDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Match", "IsConfirm", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Match", "IsConfirm");
            DropColumn("dbo.Match", "MatchDate");
        }
    }
}
