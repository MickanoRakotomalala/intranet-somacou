namespace intranet_somacou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateUser2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CreateUsers", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CreateUsers", "Password", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
