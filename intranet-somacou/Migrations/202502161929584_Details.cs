namespace intranet_somacou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Details : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Incidents", "Details", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Incidents", "Details", c => c.String());
        }
    }
}
