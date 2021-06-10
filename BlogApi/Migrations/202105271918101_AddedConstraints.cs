namespace BlogApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedConstraints : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "Content", c => c.String(nullable: false, maxLength: 3000));
            AlterColumn("dbo.Posts", "Title", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Posts", "Descriptipon", c => c.String(maxLength: 3000));
            AlterColumn("dbo.Posts", "ImageUrl", c => c.String(maxLength: 3000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "ImageUrl", c => c.String());
            AlterColumn("dbo.Posts", "Descriptipon", c => c.String());
            AlterColumn("dbo.Posts", "Title", c => c.String());
            AlterColumn("dbo.Comments", "Content", c => c.String());
        }
    }
}
