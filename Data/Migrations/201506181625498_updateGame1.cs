namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateGame1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Game", "GameNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Game", "GameNumber");
        }
    }
}
