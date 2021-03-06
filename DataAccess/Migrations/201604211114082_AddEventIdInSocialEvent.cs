namespace SCA.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddEventIdInSocialEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SocialNetworkEvent", "EventId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SocialNetworkEvent", "EventId");
        }
    }
}
