namespace intranet_somacou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpmodelIncidentDto : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Incidents", "Responsible", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Incidents", "Responsible", c => c.String(nullable: false));
        }
    }
}
