namespace JoggingTrackerCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerFieldNameWasChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Name", c => c.String());
            DropColumn("dbo.Customers", "FullName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "FullName", c => c.String());
            DropColumn("dbo.Customers", "Name");
        }
    }
}
