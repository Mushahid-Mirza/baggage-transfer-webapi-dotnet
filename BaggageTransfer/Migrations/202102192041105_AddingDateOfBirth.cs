namespace BaggageTransfer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingDateOfBirth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DateOfBirth", c => c.DateTime(nullable: false, precision: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DateOfBirth");
        }
    }
}
