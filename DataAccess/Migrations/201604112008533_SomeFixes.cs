namespace SCA.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class SomeFixes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Company", "RelationType_Id", "dbo.CompanyRelation");
            DropIndex("dbo.Company", new[] { "RelationType_Id" });
            DropColumn("dbo.Company", "RelationType_Id");
            DropTable("dbo.CompanyRelation");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CompanyRelation",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 1000),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Company", "RelationType_Id", c => c.Guid());
            CreateIndex("dbo.Company", "RelationType_Id");
            AddForeignKey("dbo.Company", "RelationType_Id", "dbo.CompanyRelation", "Id");
        }
    }
}
