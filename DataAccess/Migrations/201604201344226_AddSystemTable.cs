namespace SCA.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddSystemTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SystemSetting",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Key = c.String(nullable: false, maxLength: 64),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            //AddColumn("dbo.ClientSite", "Url", c => c.String());
        }
        
        public override void Down()
        {
            //DropColumn("dbo.ClientSite", "Url");
            DropTable("dbo.SystemSetting");
        }
    }
}
