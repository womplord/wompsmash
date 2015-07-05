namespace wompsmash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComplexDataModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Author", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Author", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Author", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.BlogPost", "Title", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Project", "Title", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Project", "Location", c => c.String(maxLength: 50));
            CreateIndex("dbo.BlogPost", "AuthorID");
            CreateIndex("dbo.Project", "AuthorID");
            AddForeignKey("dbo.BlogPost", "AuthorID", "dbo.Author", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Project", "AuthorID", "dbo.Author", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Project", "AuthorID", "dbo.Author");
            DropForeignKey("dbo.BlogPost", "AuthorID", "dbo.Author");
            DropIndex("dbo.Project", new[] { "AuthorID" });
            DropIndex("dbo.BlogPost", new[] { "AuthorID" });
            AlterColumn("dbo.Project", "Location", c => c.String());
            AlterColumn("dbo.Project", "Title", c => c.String());
            AlterColumn("dbo.BlogPost", "Title", c => c.String());
            AlterColumn("dbo.Author", "Email", c => c.String());
            AlterColumn("dbo.Author", "FirstName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Author", "LastName", c => c.String(maxLength: 50));
        }
    }
}
