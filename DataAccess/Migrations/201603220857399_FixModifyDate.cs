namespace SCA.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class FixModifyDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contact", "BirthDate", c => c.DateTime());
            AlterColumn("dbo.Contact", "LastActivityDate", c => c.DateTime());
            AlterColumn("dbo.Contact", "ModifyDate", c => c.DateTime());
            AlterColumn("dbo.Company", "ModifyDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Company", "ModifyDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Contact", "ModifyDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Contact", "LastActivityDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Contact", "BirthDate", c => c.DateTime(nullable: false));
        }
    }
}
