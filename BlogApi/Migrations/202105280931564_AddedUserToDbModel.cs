namespace BlogApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserToDbModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 150),
                        Password = c.String(nullable: false, maxLength: 400),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Comments", "Author_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "Author_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "Author_Id");
            CreateIndex("dbo.Posts", "Author_Id");
            AddForeignKey("dbo.Comments", "Author_Id", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Posts", "Author_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Author_Id", "dbo.Users");
            DropForeignKey("dbo.Comments", "Author_Id", "dbo.Users");
            DropIndex("dbo.Posts", new[] { "Author_Id" });
            DropIndex("dbo.Comments", new[] { "Author_Id" });
            DropColumn("dbo.Posts", "Author_Id");
            DropColumn("dbo.Comments", "Author_Id");
            DropTable("dbo.Users");
        }
    }
}
