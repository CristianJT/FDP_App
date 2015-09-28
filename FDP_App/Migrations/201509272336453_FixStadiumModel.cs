namespace App.FDP
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixStadiumModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Stadium", "TeamId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stadium", "TeamId", c => c.Int());
        }
    }
}
