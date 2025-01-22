namespace intranet_somacou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpIncident : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Incidents", "User", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Incidents", "Type", c => c.String(nullable: false));
            AlterColumn("dbo.Incidents", "Details", c => c.String(nullable: false));
            AlterColumn("dbo.Incidents", "Etat", c => c.String(nullable: false));
            AlterColumn("dbo.Incidents", "Action", c => c.String(nullable: false));
            AlterColumn("dbo.Incidents", "Responsible", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Incidents", "Responsible", c => c.String());
            AlterColumn("dbo.Incidents", "Action", c => c.String());
            AlterColumn("dbo.Incidents", "Etat", c => c.String());
            AlterColumn("dbo.Incidents", "Details", c => c.String());
            AlterColumn("dbo.Incidents", "Type", c => c.String());
            AlterColumn("dbo.Incidents", "User", c => c.String());
        }
    }
}
