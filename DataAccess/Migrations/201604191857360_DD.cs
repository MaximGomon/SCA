namespace SCA.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DD : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SocialNetworkEvent", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SocialNetworkEvent", "Type");
        }
    }
}
