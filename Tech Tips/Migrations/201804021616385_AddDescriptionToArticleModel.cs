namespace Tech_Tips.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescriptionToArticleModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "Description");
        }
    }
}
