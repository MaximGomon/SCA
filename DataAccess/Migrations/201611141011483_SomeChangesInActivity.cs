namespace SCA.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeChangesInActivity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activity", "Ip", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Activity", "Ip");
        }
    }
}
