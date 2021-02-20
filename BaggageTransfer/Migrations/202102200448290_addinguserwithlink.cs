namespace BaggageTransfer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addinguserwithlink : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Notifications", "UserId", c => c.String(maxLength: 128, storeType: "nvarchar"));
            CreateIndex("dbo.Notifications", "UserId");
            AddForeignKey("dbo.Notifications", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Notifications", new[] { "UserId" });
            AlterColumn("dbo.Notifications", "UserId", c => c.String(unicode: false));
        }
    }
}
