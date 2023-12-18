namespace WebApplicationNetFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedIsFirstLogin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "isFirstLogin", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "isFirstLogin");
        }
    }
}
