namespace Tech_Tips.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixCategoryIdFromIntToByteInCategoryModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Blogs", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Blogs", new[] { "Category_Id" });
            DropColumn("dbo.Blogs", "CategoryId");
            RenameColumn(table: "dbo.Blogs", name: "Category_Id", newName: "CategoryId");
            DropPrimaryKey("dbo.Categories");
            AlterColumn("dbo.Blogs", "CategoryId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Categories", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Categories", "Id");
            CreateIndex("dbo.Blogs", "CategoryId");
            AddForeignKey("dbo.Blogs", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blogs", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Blogs", new[] { "CategoryId" });
            DropPrimaryKey("dbo.Categories");
            AlterColumn("dbo.Categories", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Blogs", "CategoryId", c => c.Int());
            AddPrimaryKey("dbo.Categories", "Id");
            RenameColumn(table: "dbo.Blogs", name: "CategoryId", newName: "Category_Id");
            AddColumn("dbo.Blogs", "CategoryId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Blogs", "Category_Id");
            AddForeignKey("dbo.Blogs", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
