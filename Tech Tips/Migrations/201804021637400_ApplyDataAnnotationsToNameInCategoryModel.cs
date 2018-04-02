namespace Tech_Tips.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyDataAnnotationsToNameInCategoryModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 25));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String());
        }
    }
}
