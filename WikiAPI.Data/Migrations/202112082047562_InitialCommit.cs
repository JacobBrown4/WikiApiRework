namespace WikiAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCommit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Topics", "ContentId", "dbo.Contents");
            DropForeignKey("dbo.Contents", "Topic_TopicId", "dbo.Topics");
            DropIndex("dbo.Contents", new[] { "Topic_TopicId" });
            DropIndex("dbo.Topics", new[] { "ContentId" });
            RenameColumn(table: "dbo.Contents", name: "Topic_TopicId", newName: "TopicId");
            AlterColumn("dbo.Contents", "TopicId", c => c.Int(nullable: false));
            CreateIndex("dbo.Contents", "TopicId");
            AddForeignKey("dbo.Contents", "TopicId", "dbo.Topics", "TopicId", cascadeDelete: true);
            DropColumn("dbo.Topics", "ContentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Topics", "ContentId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Contents", "TopicId", "dbo.Topics");
            DropIndex("dbo.Contents", new[] { "TopicId" });
            AlterColumn("dbo.Contents", "TopicId", c => c.Int());
            RenameColumn(table: "dbo.Contents", name: "TopicId", newName: "Topic_TopicId");
            CreateIndex("dbo.Topics", "ContentId");
            CreateIndex("dbo.Contents", "Topic_TopicId");
            AddForeignKey("dbo.Contents", "Topic_TopicId", "dbo.Topics", "TopicId");
            AddForeignKey("dbo.Topics", "ContentId", "dbo.Contents", "ContentId", cascadeDelete: true);
        }
    }
}
