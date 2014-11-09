namespace Falcon.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Member", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Member", "Email", c => c.String());
            AlterColumn("dbo.Member", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Member", "UserName", c => c.String(maxLength: 255));
            AlterColumn("dbo.Member", "Email", c => c.String(maxLength: 255));
            DropColumn("dbo.Member", "Id");
        }
    }
}
