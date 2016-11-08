namespace SCA.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddNameForLead : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lead", "Name", c => c.String(nullable: false, maxLength: 1000));
            AddColumn("dbo.Lead", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lead", "IsDeleted");
            DropColumn("dbo.Lead", "Name");
        }
    }
}
