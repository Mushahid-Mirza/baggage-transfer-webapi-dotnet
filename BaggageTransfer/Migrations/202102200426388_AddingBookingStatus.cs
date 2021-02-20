namespace BaggageTransfer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingBookingStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BaggageRequests", "BookingStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BaggageRequests", "BookingStatus");
        }
    }
}
