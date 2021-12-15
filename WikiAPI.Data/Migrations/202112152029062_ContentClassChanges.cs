namespace WikiAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContentClassChanges : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Contents", "TopicTitle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contents", "TopicTitle", c => c.String());
        }
    }
}
