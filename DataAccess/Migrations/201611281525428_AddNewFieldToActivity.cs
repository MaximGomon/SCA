namespace SCA.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewFieldToActivity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activity", "ExternalId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Activity", "ExternalId");
        }
    }
}
