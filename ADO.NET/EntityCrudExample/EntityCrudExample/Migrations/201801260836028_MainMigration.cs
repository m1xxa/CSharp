namespace EntityCrudExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MainMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Product = c.String(nullable: false, maxLength: 180),
                        Price = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                        IdUser_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.IdUser_Id, cascadeDelete: true)
                .Index(t => t.IdUser_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        Email = c.String(nullable: false, maxLength: 80),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "IdUser_Id", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "IdUser_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
        }
    }
}
