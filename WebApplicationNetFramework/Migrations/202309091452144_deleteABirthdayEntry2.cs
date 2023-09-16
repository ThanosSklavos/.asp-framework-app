namespace WebApplicationNetFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteABirthdayEntry2 : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthday =  NULL WHERE Id = 1");
        }
        
        public override void Down()
        {
        }
    }
}
