namespace BaggageTransfer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingForeignKeyForUserEnquiry : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserEnquiries", "EnquiryRequest_Id", c => c.Long());
            CreateIndex("dbo.BaggageRequests", "RequesterEnquiryId");
            CreateIndex("dbo.BaggageRequests", "MoverEnquiryrId");
            CreateIndex("dbo.UserEnquiries", "EnquiryRequest_Id");
            AddForeignKey("dbo.UserEnquiries", "EnquiryRequest_Id", "dbo.BaggageRequests", "Id");
            AddForeignKey("dbo.BaggageRequests", "MoverEnquiryrId", "dbo.UserEnquiries", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BaggageRequests", "RequesterEnquiryId", "dbo.UserEnquiries", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BaggageRequests", "RequesterEnquiryId", "dbo.UserEnquiries");
            DropForeignKey("dbo.BaggageRequests", "MoverEnquiryrId", "dbo.UserEnquiries");
            DropForeignKey("dbo.UserEnquiries", "EnquiryRequest_Id", "dbo.BaggageRequests");
            DropIndex("dbo.UserEnquiries", new[] { "EnquiryRequest_Id" });
            DropIndex("dbo.BaggageRequests", new[] { "MoverEnquiryrId" });
            DropIndex("dbo.BaggageRequests", new[] { "RequesterEnquiryId" });
            DropColumn("dbo.UserEnquiries", "EnquiryRequest_Id");
        }
    }
}
