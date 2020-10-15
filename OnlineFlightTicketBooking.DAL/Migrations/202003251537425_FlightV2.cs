namespace OnlineFlightTicketBooking.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FlightV2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "PhoneNumber", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Accounts", "PhoneNumber", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
