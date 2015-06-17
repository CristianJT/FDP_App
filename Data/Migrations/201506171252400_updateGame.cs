namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateGame : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Game", "IsCurrent", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Game", "IsCurrent");
        }
    }
}
