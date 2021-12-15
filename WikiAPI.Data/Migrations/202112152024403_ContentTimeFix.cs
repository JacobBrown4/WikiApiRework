namespace WikiAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContentTimeFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "TopicTitle", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contents", "TopicTitle");
        }
    }
}
