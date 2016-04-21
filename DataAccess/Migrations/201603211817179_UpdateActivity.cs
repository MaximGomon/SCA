namespace SCA.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class UpdateActivity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activity", "UserAgent", c => c.String());
            AddColumn("dbo.Activity", "Cookie", c => c.String());
            AddColumn("dbo.Tag", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tag", "Description");
            DropColumn("dbo.Activity", "Cookie");
            DropColumn("dbo.Activity", "UserAgent");
        }
    }
}
