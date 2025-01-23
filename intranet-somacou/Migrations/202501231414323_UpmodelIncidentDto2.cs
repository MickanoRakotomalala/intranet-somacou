namespace intranet_somacou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpmodelIncidentDto2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Incidents", "UpdateDate", c => c.String());
        }

        public override void Down()
        {
            AlterColumn("dbo.Incidents", "UpdateDate", c => c.String(nullable: false));
        }
    }
}
