namespace WebApplicationNetFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCopiesPropInMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Copies", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Copies");
        }
    }
}
