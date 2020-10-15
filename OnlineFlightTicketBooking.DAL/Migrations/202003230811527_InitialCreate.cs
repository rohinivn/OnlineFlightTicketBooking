namespace OnlineFlightTicketBooking.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        EmailId = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false),
                        Gender = c.String(nullable: false, maxLength: 6),
                        PhoneNumber = c.String(nullable: false, maxLength: 10),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        PinCode = c.Int(nullable: false),
                        Role = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.EmailId, unique: true);
            
            CreateTable(
                "dbo.FlightClasses",
                c => new
                    {
                        FlightClassId = c.Int(nullable: false, identity: true),
                        FlightClassName = c.String(nullable: false, maxLength: 10),
                        FlightClassDescription = c.String(nullable: false),
                        Flight_FlightId = c.Int(),
                    })
                .PrimaryKey(t => t.FlightClassId)
                .ForeignKey("dbo.Flights", t => t.Flight_FlightId)
                .Index(t => t.Flight_FlightId);
            
            CreateTable(
                "dbo.FlightClassDetails",
                c => new
                    {
                        FlightClassDetailId = c.Int(nullable: false, identity: true),
                        FlightId = c.Int(nullable: false),
                        FlightClassId = c.Int(nullable: false),
                        Cost = c.Single(nullable: false),
                        NoOfSeat = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FlightClassDetailId)
                .ForeignKey("dbo.Flights", t => t.FlightId, cascadeDelete: true)
                .ForeignKey("dbo.FlightClasses", t => t.FlightClassId, cascadeDelete: true)
                .Index(t => t.FlightId)
                .Index(t => t.FlightClassId);
            
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        FlightId = c.Int(nullable: false, identity: true),
                        FlightName = c.String(nullable: false, maxLength: 20),
                        StartLocation = c.String(nullable: false, maxLength: 20),
                        TargetLoation = c.String(nullable: false, maxLength: 20),
                        DispatchDate = c.DateTime(nullable: false),
                        ArrivalDate = c.DateTime(nullable: false),
                        AvailableTickets = c.Int(nullable: false),
                        TicketPrice = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.FlightId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FlightClassDetails", "FlightClassId", "dbo.FlightClasses");
            DropForeignKey("dbo.FlightClassDetails", "FlightId", "dbo.Flights");
            DropForeignKey("dbo.FlightClasses", "Flight_FlightId", "dbo.Flights");
            DropIndex("dbo.FlightClassDetails", new[] { "FlightClassId" });
            DropIndex("dbo.FlightClassDetails", new[] { "FlightId" });
            DropIndex("dbo.FlightClasses", new[] { "Flight_FlightId" });
            DropIndex("dbo.Accounts", new[] { "EmailId" });
            DropTable("dbo.Flights");
            DropTable("dbo.FlightClassDetails");
            DropTable("dbo.FlightClasses");
            DropTable("dbo.Accounts");
        }
    }
}
