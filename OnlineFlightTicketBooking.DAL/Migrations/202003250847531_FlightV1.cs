namespace OnlineFlightTicketBooking.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FlightV1 : DbMigration
    {  
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Accounts", "Password", c => c.String(nullable: false, maxLength: 10));
            CreateIndex("dbo.Accounts", "Name", unique: true);
            DropColumn("dbo.Flights", "AvailableTickets");
            DropColumn("dbo.Flights", "TicketPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Flights", "TicketPrice", c => c.Single(nullable: false));
            AddColumn("dbo.Flights", "AvailableTickets", c => c.Int(nullable: false));
            DropIndex("dbo.Accounts", new[] { "Name" });
            AlterColumn("dbo.Accounts", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "Name", c => c.String(nullable: false));
        }
    }
}
