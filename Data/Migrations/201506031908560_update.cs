namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Game", new[] { "Fixtureid" });
            CreateIndex("dbo.Game", "FixtureId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Game", new[] { "FixtureId" });
            CreateIndex("dbo.Game", "Fixtureid");
        }
    }
}
