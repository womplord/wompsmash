namespace wompsmash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inheritence : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Author", newName: "Person");
            AlterColumn("dbo.Person", "Email", c => c.String());
            AlterColumn("dbo.Person", "DateAdded", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Person", "DateAdded", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Person", "Email", c => c.String(nullable: false));
            RenameTable(name: "dbo.Person", newName: "Author");
        }
    }
}
