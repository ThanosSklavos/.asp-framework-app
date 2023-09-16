namespace WebApplicationNetFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insertBirthdaysToCusts : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthday =  '1992-05-22' WHERE Id = 1");
            Sql("UPDATE Customers SET Birthday =  '1993-03-25' WHERE Id = 2");
        }
        
        public override void Down()
        {
        }
    }
}
