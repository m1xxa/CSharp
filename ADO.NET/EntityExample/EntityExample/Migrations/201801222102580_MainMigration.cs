namespace EntityExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MainMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 180),
                        LastName = c.String(nullable: false, maxLength: 180),
                        RegisterDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Clients");
        }
    }
}
