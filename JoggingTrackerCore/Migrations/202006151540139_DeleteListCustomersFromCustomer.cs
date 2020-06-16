namespace JoggingTrackerCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteListCustomersFromCustomer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DayResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rank = c.Int(nullable: false),
                        User = c.String(),
                        Status = c.String(),
                        Steps = c.Int(nullable: false),
                        Day = c.Int(nullable: false),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DayResults", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.DayResults", new[] { "Customer_Id" });
            DropTable("dbo.DayResults");
            DropTable("dbo.Customers");
        }
    }
}
