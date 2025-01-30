namespace intranet_somacou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpIncident : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Incidents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                        UserId = c.Int(nullable: false),
                        Type = c.String(nullable: false),
                        Details = c.String(nullable: false),
                        Etat = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        Action = c.String(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        Responsible = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Incidents", "UserId", "dbo.Users");
            DropIndex("dbo.Incidents", new[] { "UserId" });
            DropTable("dbo.Incidents");
        }
    }
}
