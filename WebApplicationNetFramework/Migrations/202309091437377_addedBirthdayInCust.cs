﻿namespace WebApplicationNetFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedBirthdayInCust : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Birthday", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Birthday");
        }
    }
}
