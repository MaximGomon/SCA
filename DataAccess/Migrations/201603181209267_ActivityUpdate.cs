namespace SCA.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActivityUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activity",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        Author_Id = c.Guid(),
                        Type_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contact", t => t.Author_Id)
                .ForeignKey("dbo.ActivityType", t => t.Type_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.Type_Id);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Email = c.String(),
                        Score = c.Int(nullable: false),
                        ReadyToByScore = c.Int(nullable: false),
                        IsNameChecked = c.Boolean(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Comment = c.String(),
                        Gender = c.Int(nullable: false),
                        Ip = c.String(),
                        LastActivityDate = c.DateTime(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyDate = c.DateTime(nullable: false),
                        Name = c.String(nullable: false, maxLength: 1000),
                        IsDeleted = c.Boolean(nullable: false),
                        Age_Id = c.Guid(),
                        ChangedBy_Id = c.Guid(),
                        CreatedBy_Id = c.Guid(),
                        Parent_Id = c.Guid(),
                        ReadyToSell_Id = c.Guid(),
                        Company_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AgeDirection", t => t.Age_Id)
                .ForeignKey("dbo.SystemUser", t => t.ChangedBy_Id)
                .ForeignKey("dbo.SystemUser", t => t.CreatedBy_Id)
                .ForeignKey("dbo.Contact", t => t.Parent_Id)
                .ForeignKey("dbo.ReadyToSellState", t => t.ReadyToSell_Id)
                .ForeignKey("dbo.Company", t => t.Company_Id)
                .Index(t => t.Age_Id)
                .Index(t => t.ChangedBy_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.Parent_Id)
                .Index(t => t.ReadyToSell_Id)
                .Index(t => t.Company_Id);
            
            CreateTable(
                "dbo.AgeDirection",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 1000),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SystemUser",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 255),
                        LastName = c.String(nullable: false, maxLength: 255),
                        Login = c.String(maxLength: 50),
                        Type_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SystemUserType", t => t.Type_Id, cascadeDelete: true)
                .Index(t => t.Type_Id);
            
            CreateTable(
                "dbo.SystemUserType",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 1000),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReadyToSellState",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 1000),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SocialNetwork",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Contact_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contact", t => t.Contact_Id)
                .Index(t => t.Contact_Id);
            
            CreateTable(
                "dbo.ClientSitePage",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RelatedUrl = c.String(),
                        Name = c.String(nullable: false, maxLength: 1000),
                        IsDeleted = c.Boolean(nullable: false),
                        Contact_Id = c.Guid(),
                        ClientSite_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contact", t => t.Contact_Id)
                .ForeignKey("dbo.ClientSite", t => t.ClientSite_Id)
                .Index(t => t.Contact_Id)
                .Index(t => t.ClientSite_Id);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 1000),
                        IsDeleted = c.Boolean(nullable: false),
                        Tag_Id = c.Guid(),
                        ClientSitePage_Id = c.Guid(),
                        Activity_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tag", t => t.Tag_Id)
                .ForeignKey("dbo.ClientSitePage", t => t.ClientSitePage_Id)
                .ForeignKey("dbo.Activity", t => t.Activity_Id)
                .Index(t => t.Tag_Id)
                .Index(t => t.ClientSitePage_Id)
                .Index(t => t.Activity_Id);
            
            CreateTable(
                "dbo.ActivityType",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 1000),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClientSite",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 1000),
                        IsDeleted = c.Boolean(nullable: false),
                        Company_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.Company_Id)
                .Index(t => t.Company_Id);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ModifyDate = c.DateTime(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        Comment = c.String(),
                        Name = c.String(nullable: false, maxLength: 1000),
                        IsDeleted = c.Boolean(nullable: false),
                        ChangedBy_Id = c.Guid(),
                        CreatedBy_Id = c.Guid(),
                        Owner_Id = c.Guid(),
                        Parent_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SystemUser", t => t.ChangedBy_Id)
                .ForeignKey("dbo.SystemUser", t => t.CreatedBy_Id)
                .ForeignKey("dbo.Contact", t => t.Owner_Id)
                .ForeignKey("dbo.Company", t => t.Parent_Id)
                .Index(t => t.ChangedBy_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.Owner_Id)
                .Index(t => t.Parent_Id);
            
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
            
            CreateTable(
                "dbo.CompanySector",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 1000),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CompanySize",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 1000),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CompanyStatus",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 1000),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactType",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 1000),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Currency",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BankCode = c.String(maxLength: 4),
                        Code = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 1000),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeePosition",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 1000),
                        IsDeleted = c.Boolean(nullable: false),
                        Employee_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employee", t => t.Employee_Id)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        People_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contact", t => t.People_Id)
                .Index(t => t.People_Id);
            
            CreateTable(
                "dbo.Payment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PayDate = c.DateTime(nullable: false),
                        Assignment = c.String(),
                        Amount = c.Double(nullable: false),
                        Currency_Id = c.Guid(),
                        Recepient_Id = c.Guid(),
                        Status_Id = c.Guid(),
                        Type_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currency", t => t.Currency_Id)
                .ForeignKey("dbo.Company", t => t.Recepient_Id)
                .ForeignKey("dbo.PaymentStatus", t => t.Status_Id)
                .ForeignKey("dbo.PaymentType", t => t.Type_Id)
                .Index(t => t.Currency_Id)
                .Index(t => t.Recepient_Id)
                .Index(t => t.Status_Id)
                .Index(t => t.Type_Id);
            
            CreateTable(
                "dbo.PaymentStatus",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 1000),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PaymentType",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 1000),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SocialNetworkType",
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
            DropForeignKey("dbo.Payment", "Type_Id", "dbo.PaymentType");
            DropForeignKey("dbo.Payment", "Status_Id", "dbo.PaymentStatus");
            DropForeignKey("dbo.Payment", "Recepient_Id", "dbo.Company");
            DropForeignKey("dbo.Payment", "Currency_Id", "dbo.Currency");
            DropForeignKey("dbo.EmployeePosition", "Employee_Id", "dbo.Employee");
            DropForeignKey("dbo.Employee", "People_Id", "dbo.Contact");
            DropForeignKey("dbo.ClientSite", "Company_Id", "dbo.Company");
            DropForeignKey("dbo.Company", "Parent_Id", "dbo.Company");
            DropForeignKey("dbo.Company", "Owner_Id", "dbo.Contact");
            DropForeignKey("dbo.Contact", "Company_Id", "dbo.Company");
            DropForeignKey("dbo.Company", "CreatedBy_Id", "dbo.SystemUser");
            DropForeignKey("dbo.Company", "ChangedBy_Id", "dbo.SystemUser");
            DropForeignKey("dbo.ClientSitePage", "ClientSite_Id", "dbo.ClientSite");
            DropForeignKey("dbo.Activity", "Type_Id", "dbo.ActivityType");
            DropForeignKey("dbo.Tag", "Activity_Id", "dbo.Activity");
            DropForeignKey("dbo.Activity", "Author_Id", "dbo.Contact");
            DropForeignKey("dbo.ClientSitePage", "Contact_Id", "dbo.Contact");
            DropForeignKey("dbo.Tag", "ClientSitePage_Id", "dbo.ClientSitePage");
            DropForeignKey("dbo.Tag", "Tag_Id", "dbo.Tag");
            DropForeignKey("dbo.SocialNetwork", "Contact_Id", "dbo.Contact");
            DropForeignKey("dbo.Contact", "ReadyToSell_Id", "dbo.ReadyToSellState");
            DropForeignKey("dbo.Contact", "Parent_Id", "dbo.Contact");
            DropForeignKey("dbo.Contact", "CreatedBy_Id", "dbo.SystemUser");
            DropForeignKey("dbo.Contact", "ChangedBy_Id", "dbo.SystemUser");
            DropForeignKey("dbo.SystemUser", "Type_Id", "dbo.SystemUserType");
            DropForeignKey("dbo.Contact", "Age_Id", "dbo.AgeDirection");
            DropIndex("dbo.Payment", new[] { "Type_Id" });
            DropIndex("dbo.Payment", new[] { "Status_Id" });
            DropIndex("dbo.Payment", new[] { "Recepient_Id" });
            DropIndex("dbo.Payment", new[] { "Currency_Id" });
            DropIndex("dbo.Employee", new[] { "People_Id" });
            DropIndex("dbo.EmployeePosition", new[] { "Employee_Id" });
            DropIndex("dbo.Company", new[] { "Parent_Id" });
            DropIndex("dbo.Company", new[] { "Owner_Id" });
            DropIndex("dbo.Company", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Company", new[] { "ChangedBy_Id" });
            DropIndex("dbo.ClientSite", new[] { "Company_Id" });
            DropIndex("dbo.Tag", new[] { "Activity_Id" });
            DropIndex("dbo.Tag", new[] { "ClientSitePage_Id" });
            DropIndex("dbo.Tag", new[] { "Tag_Id" });
            DropIndex("dbo.ClientSitePage", new[] { "ClientSite_Id" });
            DropIndex("dbo.ClientSitePage", new[] { "Contact_Id" });
            DropIndex("dbo.SocialNetwork", new[] { "Contact_Id" });
            DropIndex("dbo.SystemUser", new[] { "Type_Id" });
            DropIndex("dbo.Contact", new[] { "Company_Id" });
            DropIndex("dbo.Contact", new[] { "ReadyToSell_Id" });
            DropIndex("dbo.Contact", new[] { "Parent_Id" });
            DropIndex("dbo.Contact", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Contact", new[] { "ChangedBy_Id" });
            DropIndex("dbo.Contact", new[] { "Age_Id" });
            DropIndex("dbo.Activity", new[] { "Type_Id" });
            DropIndex("dbo.Activity", new[] { "Author_Id" });
            DropTable("dbo.SocialNetworkType");
            DropTable("dbo.PaymentType");
            DropTable("dbo.PaymentStatus");
            DropTable("dbo.Payment");
            DropTable("dbo.Employee");
            DropTable("dbo.EmployeePosition");
            DropTable("dbo.Currency");
            DropTable("dbo.ContactType");
            DropTable("dbo.CompanyStatus");
            DropTable("dbo.CompanySize");
            DropTable("dbo.CompanySector");
            DropTable("dbo.CompanyRelation");
            DropTable("dbo.Company");
            DropTable("dbo.ClientSite");
            DropTable("dbo.ActivityType");
            DropTable("dbo.Tag");
            DropTable("dbo.ClientSitePage");
            DropTable("dbo.SocialNetwork");
            DropTable("dbo.ReadyToSellState");
            DropTable("dbo.SystemUserType");
            DropTable("dbo.SystemUser");
            DropTable("dbo.AgeDirection");
            DropTable("dbo.Contact");
            DropTable("dbo.Activity");
        }
    }
}
