namespace HotelBookingMRProjekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBaza : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HotelSobas", "NazivSobe", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HotelSobas", "NazivSobe", c => c.String());
        }
    }
}
