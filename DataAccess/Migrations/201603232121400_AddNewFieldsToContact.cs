namespace SCA.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddNewFieldsToContact : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contact", "ReadyToBuyScore", c => c.Int(nullable: false));
            AddColumn("dbo.Contact", "Status_Id", c => c.Guid());
            AddColumn("dbo.Contact", "Type_Id", c => c.Guid());
            CreateIndex("dbo.Contact", "Status_Id");
            CreateIndex("dbo.Contact", "Type_Id");
            AddForeignKey("dbo.Contact", "Status_Id", "dbo.ContactStatus", "Id");
            AddForeignKey("dbo.Contact", "Type_Id", "dbo.ContactType", "Id");
            DropColumn("dbo.Contact", "ReadyToByScore");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contact", "ReadyToByScore", c => c.Int(nullable: false));
            DropForeignKey("dbo.Contact", "Type_Id", "dbo.ContactType");
            DropForeignKey("dbo.Contact", "Status_Id", "dbo.ContactStatus");
            DropIndex("dbo.Contact", new[] { "Type_Id" });
            DropIndex("dbo.Contact", new[] { "Status_Id" });
            DropColumn("dbo.Contact", "Type_Id");
            DropColumn("dbo.Contact", "Status_Id");
            DropColumn("dbo.Contact", "ReadyToBuyScore");
        }
    }
}
