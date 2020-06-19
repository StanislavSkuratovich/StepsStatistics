namespace JoggingTrackerCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCommit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DayResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rank = c.Int(nullable: false),
                        IsFinished = c.Boolean(nullable: false),
                        Steps = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        DayNumber = c.Int(nullable: false),
                        Day_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Days", t => t.Day_Id)
                .Index(t => t.CustomerId)
                .Index(t => t.Day_Id);
            
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DayResults", "Day_Id", "dbo.Days");
            DropForeignKey("dbo.DayResults", "CustomerId", "dbo.Customers");
            DropIndex("dbo.DayResults", new[] { "Day_Id" });
            DropIndex("dbo.DayResults", new[] { "CustomerId" });
            DropTable("dbo.Days");
            DropTable("dbo.DayResults");
            DropTable("dbo.Customers");
        }
    }
}
