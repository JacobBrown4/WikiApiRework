namespace WikiAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SwaggerAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subcontents", "Content", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subcontents", "Content");
        }
    }
}
