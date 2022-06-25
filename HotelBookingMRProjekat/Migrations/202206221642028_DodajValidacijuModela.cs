namespace HotelBookingMRProjekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodajValidacijuModela : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookingSobas", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.BookingSobas", new[] { "ApplicationUserId" });
            AlterColumn("dbo.BookingSobas", "ApplicationUserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.BookingSobas", "ApplicationUserId");
            AddForeignKey("dbo.BookingSobas", "ApplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookingSobas", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.BookingSobas", new[] { "ApplicationUserId" });
            AlterColumn("dbo.BookingSobas", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.BookingSobas", "ApplicationUserId");
            AddForeignKey("dbo.BookingSobas", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
    }
}
