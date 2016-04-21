namespace SCA.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddNewDbEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lead",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 1000),
                        IsDeleted = c.Boolean(nullable: false),
                        Buyer_Id = c.Guid(),
                        Type_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contact", t => t.Buyer_Id)
                .ForeignKey("dbo.LeadType", t => t.Type_Id)
                .Index(t => t.Buyer_Id)
                .Index(t => t.Type_Id);
            
            CreateTable(
                "dbo.LeadType",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Tag", "LeadType_Id", c => c.Guid());
            CreateIndex("dbo.Tag", "LeadType_Id");
            AddForeignKey("dbo.Tag", "LeadType_Id", "dbo.LeadType", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lead", "Type_Id", "dbo.LeadType");
            DropForeignKey("dbo.Tag", "LeadType_Id", "dbo.LeadType");
            DropForeignKey("dbo.Lead", "Buyer_Id", "dbo.Contact");
            DropIndex("dbo.Lead", new[] { "Type_Id" });
            DropIndex("dbo.Lead", new[] { "Buyer_Id" });
            DropIndex("dbo.Tag", new[] { "LeadType_Id" });
            DropColumn("dbo.Tag", "LeadType_Id");
            DropTable("dbo.LeadType");
            DropTable("dbo.Lead");
        }
    }
}
