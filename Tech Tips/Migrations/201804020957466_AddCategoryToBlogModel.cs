namespace Tech_Tips.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryToBlogModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "CategoryId", c => c.Byte(nullable: false));
            AddColumn("dbo.Blogs", "Category_Id", c => c.Int());
            CreateIndex("dbo.Blogs", "Category_Id");
            AddForeignKey("dbo.Blogs", "Category_Id", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blogs", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Blogs", new[] { "Category_Id" });
            DropColumn("dbo.Blogs", "Category_Id");
            DropColumn("dbo.Blogs", "CategoryId");
        }
    }
}
