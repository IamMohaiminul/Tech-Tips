namespace Tech_Tips.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategories : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Categories ON");
            Sql("INSERT INTO Categories (Id, Name) VALUES (1, 'Web Application')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (2, 'Desktop Application')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (3, 'Mobile Application')");
        }
        
        public override void Down()
        {
        }
    }
}
