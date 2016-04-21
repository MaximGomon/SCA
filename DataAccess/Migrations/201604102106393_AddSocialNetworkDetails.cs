namespace SCA.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddSocialNetworkDetails : DbMigration
    {
        public override void Up()
        {
            //RenameTable(name: "dbo.SocialNetwork", newName: "SocialNetworkEvent");
            RenameColumn(table: "dbo.SocialNetworkEvent", name: "Contact_Id", newName: "Avtor_Id");
            RenameIndex(table: "dbo.SocialNetworkEvent", name: "IX_Contact_Id", newName: "IX_Avtor_Id");
            AddColumn("dbo.Activity", "SocialNetworkEvent_Id", c => c.Guid());
            AddColumn("dbo.Contact", "Link", c => c.String());
            AddColumn("dbo.Tag", "SocialNetworkEvent_Id", c => c.Guid());
            AddColumn("dbo.SocialNetworkEvent", "Link", c => c.String());
            AddColumn("dbo.SocialNetworkEvent", "Message", c => c.String());
            AddColumn("dbo.SocialNetworkEvent", "DateCreated", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Activity", "SocialNetworkEvent_Id");
            CreateIndex("dbo.Tag", "SocialNetworkEvent_Id");
            AddForeignKey("dbo.Activity", "SocialNetworkEvent_Id", "dbo.SocialNetworkEvent", "Id");
            AddForeignKey("dbo.Tag", "SocialNetworkEvent_Id", "dbo.SocialNetworkEvent", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tag", "SocialNetworkEvent_Id", "dbo.SocialNetworkEvent");
            DropForeignKey("dbo.Activity", "SocialNetworkEvent_Id", "dbo.SocialNetworkEvent");
            DropIndex("dbo.Tag", new[] { "SocialNetworkEvent_Id" });
            DropIndex("dbo.Activity", new[] { "SocialNetworkEvent_Id" });
            DropColumn("dbo.SocialNetworkEvent", "DateCreated");
            DropColumn("dbo.SocialNetworkEvent", "Message");
            DropColumn("dbo.SocialNetworkEvent", "Link");
            DropColumn("dbo.Tag", "SocialNetworkEvent_Id");
            DropColumn("dbo.Contact", "Link");
            DropColumn("dbo.Activity", "SocialNetworkEvent_Id");
            RenameIndex(table: "dbo.SocialNetworkEvent", name: "IX_Avtor_Id", newName: "IX_Contact_Id");
            RenameColumn(table: "dbo.SocialNetworkEvent", name: "Avtor_Id", newName: "Contact_Id");
            //RenameTable(name: "dbo.SocialNetworkEvent", newName: "SocialNetwork");
        }
    }
}
