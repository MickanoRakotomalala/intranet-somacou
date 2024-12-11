namespace intranet_somacou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CreateUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Matricule = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 20),
                        Address = c.String(nullable: false, maxLength: 30),
                        Poste = c.String(nullable: false, maxLength: 50),
                        Role = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 20),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CreateUsers");
        }
    }
}
