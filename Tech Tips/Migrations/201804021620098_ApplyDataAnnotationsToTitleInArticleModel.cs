namespace Tech_Tips.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyDataAnnotationsToTitleInArticleModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "Title", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Articles", "Title", c => c.String());
        }
    }
}
