namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migAdminMail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "Mail", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "Mail");
        }
    }
}
