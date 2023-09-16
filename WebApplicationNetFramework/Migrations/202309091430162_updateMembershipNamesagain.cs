namespace WebApplicationNetFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMembershipNamesagain : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Free Plan' WHERE ID = 1");
            Sql("UPDATE MembershipTypes SET Name = 'Economy Plan' WHERE ID = 2");
            Sql("UPDATE MembershipTypes SET Name = 'Premium Plan' WHERE ID = 3");
            Sql("UPDATE MembershipTypes SET Name = 'ForRichGuysOnlyLol Plan' WHERE ID = 4");
        }
        
        public override void Down()
        {
        }
    }
}
