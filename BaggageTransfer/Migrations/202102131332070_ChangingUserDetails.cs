namespace BaggageTransfer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingUserDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FullName", c => c.String(unicode: false));
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(unicode: false));
            DropColumn("dbo.AspNetUsers", "FullName");
        }
    }
}
