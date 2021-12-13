namespace WikiAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "AuthorId", c => c.Guid(nullable: false));
            DropColumn("dbo.Contents", "Author_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contents", "Author_Id", c => c.Guid(nullable: false));
            DropColumn("dbo.Contents", "AuthorId");
        }
    }
}
