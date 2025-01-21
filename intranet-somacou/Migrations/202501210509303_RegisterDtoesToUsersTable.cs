namespace intranet_somacou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegisterDtoesToUsersTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.RegisterDtoes", newName: "Users");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Users", newName: "RegisterDtoes");
        }
    }
}
