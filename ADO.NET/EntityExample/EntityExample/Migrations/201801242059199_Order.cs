namespace EntityExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Order : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OrderName = c.String(),
                        Value = c.Int(nullable: false),
                        IdClient_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.IdClient_Id)
                .Index(t => t.IdClient_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "IdClient_Id", "dbo.Clients");
            DropIndex("dbo.Orders", new[] { "IdClient_Id" });
            DropTable("dbo.Orders");
        }
    }
}
