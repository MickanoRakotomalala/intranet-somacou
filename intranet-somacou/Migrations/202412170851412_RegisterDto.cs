namespace intranet_somacou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegisterDto : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CreateUsers", newName: "RegisterDtoes");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.RegisterDtoes", newName: "CreateUsers");
        }
    }
}
