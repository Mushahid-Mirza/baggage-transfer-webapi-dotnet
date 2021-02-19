namespace BaggageTransfer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingRelationBetweenUserAndUserEnquiry : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserEnquiries", "UserId", c => c.String(maxLength: 128, storeType: "nvarchar"));
            CreateIndex("dbo.UserEnquiries", "UserId");
            AddForeignKey("dbo.UserEnquiries", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserEnquiries", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UserEnquiries", new[] { "UserId" });
            AlterColumn("dbo.UserEnquiries", "UserId", c => c.String(unicode: false));
        }
    }
}
