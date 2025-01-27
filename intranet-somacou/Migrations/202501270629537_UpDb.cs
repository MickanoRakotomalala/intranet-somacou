namespace intranet_somacou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Incidents", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Incidents", "UserId");
            AddForeignKey("dbo.Incidents", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Incidents", "UserId", "dbo.Users");
            DropIndex("dbo.Incidents", new[] { "UserId" });
            DropColumn("dbo.Incidents", "UserId");
        }
    }
}
