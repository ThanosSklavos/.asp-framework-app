namespace WebApplicationNetFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteABirthdayEntry : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthday =  '' WHERE Id = 1");

        }
        
        public override void Down()
        {
        }
    }
}
