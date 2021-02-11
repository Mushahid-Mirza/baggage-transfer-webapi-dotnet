namespace BaggageTransfer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequestTableChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BaggageRequests", "RequesterEnquiryId", c => c.Long(nullable: false));
            AddColumn("dbo.BaggageRequests", "MoverEnquiryrId", c => c.String(unicode: false));
            AddColumn("dbo.BaggageRequests", "ApprovedCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.BaggageRequests", "RequesterId");
            DropColumn("dbo.BaggageRequests", "MoverUserId");
            DropColumn("dbo.BaggageRequests", "StartLocationName");
            DropColumn("dbo.BaggageRequests", "StartGeoPosition");
            DropColumn("dbo.BaggageRequests", "EndLocationName");
            DropColumn("dbo.BaggageRequests", "EndGeoPosition");
            DropColumn("dbo.BaggageRequests", "EstimatedCost");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BaggageRequests", "EstimatedCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.BaggageRequests", "EndGeoPosition", c => c.String(unicode: false));
            AddColumn("dbo.BaggageRequests", "EndLocationName", c => c.String(unicode: false));
            AddColumn("dbo.BaggageRequests", "StartGeoPosition", c => c.String(unicode: false));
            AddColumn("dbo.BaggageRequests", "StartLocationName", c => c.String(unicode: false));
            AddColumn("dbo.BaggageRequests", "MoverUserId", c => c.String(unicode: false));
            AddColumn("dbo.BaggageRequests", "RequesterId", c => c.String(unicode: false));
            DropColumn("dbo.BaggageRequests", "ApprovedCost");
            DropColumn("dbo.BaggageRequests", "MoverEnquiryrId");
            DropColumn("dbo.BaggageRequests", "RequesterEnquiryId");
        }
    }
}
