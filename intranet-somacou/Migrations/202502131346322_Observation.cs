namespace intranet_somacou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Observation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Incidents", "Observation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Incidents", "Observation");
        }
    }
}
