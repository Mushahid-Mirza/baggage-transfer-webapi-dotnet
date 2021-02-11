namespace BaggageTransfer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingUserEnquiry : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserEnquiries",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserId = c.String(unicode: false),
                        StartLat = c.Single(nullable: false),
                        StartLong = c.Single(nullable: false),
                        EndLat = c.Single(nullable: false),
                        EndLong = c.Single(nullable: false),
                        RequestType = c.Int(nullable: false),
                        ActiveTill = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.BaggageRequests", "MoverEnquiryrId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BaggageRequests", "MoverEnquiryrId", c => c.String(unicode: false));
            DropTable("dbo.UserEnquiries");
        }
    }
}
