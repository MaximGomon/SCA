namespace SCA.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddNewFieldsToClientSite : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ClientSite", name: "Company_Id", newName: "Owner_Id");
            RenameIndex(table: "dbo.ClientSite", name: "IX_Company_Id", newName: "IX_Owner_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ClientSite", name: "IX_Owner_Id", newName: "IX_Company_Id");
            RenameColumn(table: "dbo.ClientSite", name: "Owner_Id", newName: "Company_Id");
        }
    }
}
