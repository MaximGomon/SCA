namespace SCA.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class CompanyUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Company", "RelationType_Id", c => c.Guid());
            AddColumn("dbo.Company", "Sector_Id", c => c.Guid());
            AddColumn("dbo.Company", "Size_Id", c => c.Guid());
            AddColumn("dbo.Company", "Status_Id", c => c.Guid());
            AddColumn("dbo.Company", "Type_Id", c => c.Guid());
            AddColumn("dbo.LeadType", "Name", c => c.String(nullable: false, maxLength: 1000));
            AddColumn("dbo.LeadType", "IsDeleted", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Company", "RelationType_Id");
            CreateIndex("dbo.Company", "Sector_Id");
            CreateIndex("dbo.Company", "Size_Id");
            CreateIndex("dbo.Company", "Status_Id");
            CreateIndex("dbo.Company", "Type_Id");
            AddForeignKey("dbo.Company", "RelationType_Id", "dbo.CompanyRelation", "Id");
            AddForeignKey("dbo.Company", "Sector_Id", "dbo.CompanySector", "Id");
            AddForeignKey("dbo.Company", "Size_Id", "dbo.CompanySize", "Id");
            AddForeignKey("dbo.Company", "Status_Id", "dbo.CompanyStatus", "Id");
            AddForeignKey("dbo.Company", "Type_Id", "dbo.CompanyType", "Id");
            DropColumn("dbo.Lead", "Name");
            DropColumn("dbo.Lead", "IsDeleted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lead", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Lead", "Name", c => c.String(nullable: false, maxLength: 1000));
            DropForeignKey("dbo.Company", "Type_Id", "dbo.CompanyType");
            DropForeignKey("dbo.Company", "Status_Id", "dbo.CompanyStatus");
            DropForeignKey("dbo.Company", "Size_Id", "dbo.CompanySize");
            DropForeignKey("dbo.Company", "Sector_Id", "dbo.CompanySector");
            DropForeignKey("dbo.Company", "RelationType_Id", "dbo.CompanyRelation");
            DropIndex("dbo.Company", new[] { "Type_Id" });
            DropIndex("dbo.Company", new[] { "Status_Id" });
            DropIndex("dbo.Company", new[] { "Size_Id" });
            DropIndex("dbo.Company", new[] { "Sector_Id" });
            DropIndex("dbo.Company", new[] { "RelationType_Id" });
            DropColumn("dbo.LeadType", "IsDeleted");
            DropColumn("dbo.LeadType", "Name");
            DropColumn("dbo.Company", "Type_Id");
            DropColumn("dbo.Company", "Status_Id");
            DropColumn("dbo.Company", "Size_Id");
            DropColumn("dbo.Company", "Sector_Id");
            DropColumn("dbo.Company", "RelationType_Id");
        }
    }
}
