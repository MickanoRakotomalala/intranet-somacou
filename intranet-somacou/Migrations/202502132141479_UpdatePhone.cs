namespace intranet_somacou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePhone : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Incidents", "Phone_Id", "dbo.Users");
            DropIndex("dbo.Incidents", new[] { "Phone_Id" });
            AddColumn("dbo.Incidents", "Phone", c => c.String());
            DropColumn("dbo.Incidents", "Phone_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Incidents", "Phone_Id", c => c.Int());
            DropColumn("dbo.Incidents", "Phone");
            CreateIndex("dbo.Incidents", "Phone_Id");
            AddForeignKey("dbo.Incidents", "Phone_Id", "dbo.Users", "Id");
        }
    }
}
