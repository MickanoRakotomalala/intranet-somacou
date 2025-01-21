namespace intranet_somacou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Incidents : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Incidents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User = c.String(),
                        Type = c.String(),
                        Details = c.String(),
                        Etat = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        Action = c.String(),
                        UpdateDate = c.DateTime(nullable: false),
                        Responsible = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Incidents");
        }
    }
}
