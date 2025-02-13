namespace intranet_somacou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAddINCIDENT : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Incidents", "UserName", c => c.String());
            AlterColumn("dbo.Incidents", "Etat", c => c.String());
            AlterColumn("dbo.Incidents", "Action", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Incidents", "Action", c => c.String(nullable: false));
            AlterColumn("dbo.Incidents", "Etat", c => c.String(nullable: false));
            AlterColumn("dbo.Incidents", "UserName", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
