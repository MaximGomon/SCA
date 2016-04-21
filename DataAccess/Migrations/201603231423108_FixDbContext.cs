namespace SCA.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class FixDbContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompanyType",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 1000),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactStatus",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 1000),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContactStatus");
            DropTable("dbo.CompanyType");
        }
    }
}
