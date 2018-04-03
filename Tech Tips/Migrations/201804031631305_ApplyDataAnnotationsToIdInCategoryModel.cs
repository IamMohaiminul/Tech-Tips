namespace Tech_Tips.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyDataAnnotationsToIdInCategoryModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Articles", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Blogs", "CategoryId", "dbo.Categories");
            DropPrimaryKey("dbo.Categories");
            AlterColumn("dbo.Categories", "Id", c => c.Byte(nullable: false, identity: true));
            AddPrimaryKey("dbo.Categories", "Id");
            AddForeignKey("dbo.Articles", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Blogs", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blogs", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Articles", "CategoryId", "dbo.Categories");
            DropPrimaryKey("dbo.Categories");
            AlterColumn("dbo.Categories", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Categories", "Id");
            AddForeignKey("dbo.Blogs", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Articles", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
