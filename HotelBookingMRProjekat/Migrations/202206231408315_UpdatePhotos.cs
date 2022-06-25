namespace HotelBookingMRProjekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePhotos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Photos", "HotelSobaId", c => c.Int(nullable: false));
            AlterColumn("dbo.Photos", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.Photos", "HotelSobaId");
            AddForeignKey("dbo.Photos", "HotelSobaId", "dbo.HotelSobas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "HotelSobaId", "dbo.HotelSobas");
            DropIndex("dbo.Photos", new[] { "HotelSobaId" });
            AlterColumn("dbo.Photos", "Name", c => c.String());
            DropColumn("dbo.Photos", "HotelSobaId");
        }
    }
}
