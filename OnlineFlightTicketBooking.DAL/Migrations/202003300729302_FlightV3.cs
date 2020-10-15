namespace OnlineFlightTicketBooking.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FlightV3 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Accounts", new[] { "Name" });
            DropIndex("dbo.Accounts", new[] { "EmailId" });
            AlterColumn("dbo.Accounts", "Name", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Accounts", "EmailId", c => c.String(nullable: false, maxLength: 20, unicode: false));
            AlterColumn("dbo.Accounts", "Password", c => c.String(nullable: false, maxLength: 10, unicode: false));
            AlterColumn("dbo.Accounts", "Gender", c => c.String(nullable: false, maxLength: 6, unicode: false));
            AlterColumn("dbo.Accounts", "Role", c => c.String(maxLength: 5, unicode: false));
            AlterColumn("dbo.FlightClasses", "FlightClassName", c => c.String(nullable: false, maxLength: 10, unicode: false));
            AlterColumn("dbo.Flights", "FlightName", c => c.String(nullable: false, maxLength: 20, unicode: false));
            AlterColumn("dbo.Flights", "StartLocation", c => c.String(nullable: false, maxLength: 20, unicode: false));
            AlterColumn("dbo.Flights", "TargetLoation", c => c.String(nullable: false, maxLength: 20, unicode: false));
            CreateIndex("dbo.Accounts", "Name", unique: true);
            CreateIndex("dbo.Accounts", "EmailId", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Accounts", new[] { "EmailId" });
            DropIndex("dbo.Accounts", new[] { "Name" });
            AlterColumn("dbo.Flights", "TargetLoation", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Flights", "StartLocation", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Flights", "FlightName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.FlightClasses", "FlightClassName", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Accounts", "Role", c => c.String(maxLength: 5));
            AlterColumn("dbo.Accounts", "Gender", c => c.String(nullable: false, maxLength: 6));
            AlterColumn("dbo.Accounts", "Password", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Accounts", "EmailId", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Accounts", "Name", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Accounts", "EmailId", unique: true);
            CreateIndex("dbo.Accounts", "Name", unique: true);
        }
    }
}
