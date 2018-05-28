namespace BlogMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostIDtoegevoegd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "Post_ID", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "Post_ID" });
            RenameColumn(table: "dbo.Comments", name: "Post_ID", newName: "PostID");
            AlterColumn("dbo.Comments", "PostID", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "PostID");
            AddForeignKey("dbo.Comments", "PostID", "dbo.Posts", "ID", cascadeDelete: false); // KARIM: cascadeDelete: true veranderd in false, zodat Comments niet gedelete worden als je de bijbehorende post delete... Dit zorgde voor de fout tijdens de les
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "PostID", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "PostID" });
            AlterColumn("dbo.Comments", "PostID", c => c.Int());
            RenameColumn(table: "dbo.Comments", name: "PostID", newName: "Post_ID");
            CreateIndex("dbo.Comments", "Post_ID");
            AddForeignKey("dbo.Comments", "Post_ID", "dbo.Posts", "ID");
        }
    }
}
