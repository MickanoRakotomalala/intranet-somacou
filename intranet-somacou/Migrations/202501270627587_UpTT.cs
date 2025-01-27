namespace intranet_somacou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpTT : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Incidents", "UserName", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Incidents", "User");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Incidents", "User", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Incidents", "UserName");
        }
    }
}
