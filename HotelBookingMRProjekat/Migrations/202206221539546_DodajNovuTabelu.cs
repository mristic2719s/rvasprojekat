namespace HotelBookingMRProjekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodajNovuTabelu : DbMigration
    {
        public override void Up()
        {
           
            CreateTable(
                "dbo.BookingSobas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OstajanjeOd = c.DateTime(nullable: false),
                        OstajanjeDo = c.DateTime(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                        HotelSobaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.HotelSobas", t => t.HotelSobaId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.HotelSobaId);
            
          
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HotelSobaId = c.Int(nullable: false),
                        ApplicationUserId = c.Int(nullable: false),
                        FromDatum = c.DateTime(nullable: false),
                        ToDatum = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.BookingSobas", "HotelSobaId", "dbo.HotelSobas");
            DropForeignKey("dbo.BookingSobas", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.BookingSobas", new[] { "HotelSobaId" });
            DropIndex("dbo.BookingSobas", new[] { "ApplicationUserId" });
            DropTable("dbo.BookingSobas");
            CreateIndex("dbo.Bookings", "ApplicationUser_Id");
            CreateIndex("dbo.Bookings", "HotelSobaId");
            AddForeignKey("dbo.Bookings", "HotelSobaId", "dbo.HotelSobas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Bookings", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
