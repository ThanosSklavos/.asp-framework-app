namespace WebApplicationNetFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedHasLoggedinbefore : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "HasLoggedInBefore", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "HasLoggedInBefore");
        }
    }
}
