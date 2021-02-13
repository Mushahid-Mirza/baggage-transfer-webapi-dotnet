namespace BaggageTransfer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingUserDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(unicode: false));
            AddColumn("dbo.AspNetUsers", "AadharUrl", c => c.String(unicode: false));
            AddColumn("dbo.AspNetUsers", "Address", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "AadharUrl");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
