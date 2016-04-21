namespace SCA.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class FillDictionary : DbMigration
    {
        public override void Up()
        {
            SqlFile("FillDictionary.sql");
        }
        
        public override void Down()
        {
        }
    }
}
