namespace intranet_somacou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Incidents", "Phone_Id", c => c.Int());
            CreateIndex("dbo.Incidents", "Phone_Id");
            AddForeignKey("dbo.Incidents", "Phone_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Incidents", "Phone_Id", "dbo.Users");
            DropIndex("dbo.Incidents", new[] { "Phone_Id" });
            DropColumn("dbo.Incidents", "Phone_Id");
        }
    }
}
