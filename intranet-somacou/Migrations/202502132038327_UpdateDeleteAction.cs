namespace intranet_somacou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDeleteAction : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Incidents", "Action");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Incidents", "Action", c => c.String());
        }
    }
}
