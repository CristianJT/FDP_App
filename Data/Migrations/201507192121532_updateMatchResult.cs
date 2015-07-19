namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMatchResult : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Match", "HomeResult", c => c.Int());
            AlterColumn("dbo.Match", "AwayResult", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Match", "AwayResult", c => c.Int(nullable: false));
            AlterColumn("dbo.Match", "HomeResult", c => c.Int(nullable: false));
        }
    }
}
