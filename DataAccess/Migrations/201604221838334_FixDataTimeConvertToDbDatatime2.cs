namespace SCA.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class FixDataTimeConvertToDbDatatime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contact", "BirthDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Contact", "LastActivityDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Contact", "CreateDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Contact", "ModifyDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            DropIndex("dbo.SocialNetworkEvent", "DF__SocialNet__DateC__6EF57B66");
            DropColumn("dbo.SocialNetworkEvent", "DateCreated");
            AddColumn("dbo.SocialNetworkEvent", "CreateDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Company", "ModifyDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Company", "CreateDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Payment", "PayDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Payment", "PayDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Company", "CreateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Company", "ModifyDate", c => c.DateTime());
            AlterColumn("dbo.SocialNetworkEvent", "DateCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Contact", "ModifyDate", c => c.DateTime());
            AlterColumn("dbo.Contact", "CreateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Contact", "LastActivityDate", c => c.DateTime());
            AlterColumn("dbo.Contact", "BirthDate", c => c.DateTime());
        }
    }
}
