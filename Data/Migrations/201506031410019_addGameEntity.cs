namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addGameEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        GameId = c.Int(nullable: false, identity: true),
                        Fixtureid = c.Int(nullable: false),
                        IsSpecialGame = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.GameId)
                .ForeignKey("dbo.Fixture", t => t.Fixtureid, cascadeDelete: true)
                .Index(t => t.Fixtureid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Game", "Fixtureid", "dbo.Fixture");
            DropIndex("dbo.Game", new[] { "Fixtureid" });
            DropTable("dbo.Game");
        }
    }
}
