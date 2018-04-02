namespace Tech_Tips.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescriptionToBlogModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "Description");
        }
    }
}
