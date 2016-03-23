namespace SCA.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixTags : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tag", "Activity_Id", "dbo.Activity");
            DropIndex("dbo.Tag", new[] { "Activity_Id" });
            CreateTable(
                "dbo.ActivityTag",
                c => new
                    {
                        Activity_Id = c.Guid(nullable: false),
                        Tag_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Activity_Id, t.Tag_Id })
                .ForeignKey("dbo.Activity", t => t.Activity_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tag", t => t.Tag_Id, cascadeDelete: true)
                .Index(t => t.Activity_Id)
                .Index(t => t.Tag_Id);
            
            DropColumn("dbo.Tag", "Activity_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tag", "Activity_Id", c => c.Guid());
            DropForeignKey("dbo.ActivityTag", "Tag_Id", "dbo.Tag");
            DropForeignKey("dbo.ActivityTag", "Activity_Id", "dbo.Activity");
            DropIndex("dbo.ActivityTag", new[] { "Tag_Id" });
            DropIndex("dbo.ActivityTag", new[] { "Activity_Id" });
            DropTable("dbo.ActivityTag");
            CreateIndex("dbo.Tag", "Activity_Id");
            AddForeignKey("dbo.Tag", "Activity_Id", "dbo.Activity", "Id");
        }
    }
}
