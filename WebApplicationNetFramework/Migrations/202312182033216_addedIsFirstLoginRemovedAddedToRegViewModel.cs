namespace WebApplicationNetFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedIsFirstLoginRemovedAddedToRegViewModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "isFirstLogin");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "isFirstLogin", c => c.Boolean(nullable: false));
        }
    }
}
