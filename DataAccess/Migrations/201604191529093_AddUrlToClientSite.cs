namespace SCA.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddUrlToClientSite : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClientSite", "Url", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClientSite", "Url");
        }
    }
}
