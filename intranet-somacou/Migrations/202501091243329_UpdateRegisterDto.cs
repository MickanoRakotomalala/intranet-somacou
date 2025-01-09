namespace intranet_somacou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRegisterDto : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RegisterDtoes", "Role", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RegisterDtoes", "Role", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
