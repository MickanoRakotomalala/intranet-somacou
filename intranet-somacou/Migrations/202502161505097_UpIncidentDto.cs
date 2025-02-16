namespace intranet_somacou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpIncidentDto : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Incidents", "Type", c => c.String());
            AlterColumn("dbo.Incidents", "Details", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Incidents", "Details", c => c.String(nullable: false));
            AlterColumn("dbo.Incidents", "Type", c => c.String(nullable: false));
        }
    }
}
