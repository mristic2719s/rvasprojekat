namespace HotelBookingMRProjekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodatPhotos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Fotografijes", "HotelSobaId", "dbo.HotelSobas");
            DropIndex("dbo.Fotografijes", new[] { "HotelSobaId" });
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ContentType = c.String(),
                        Data = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Fotografijes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Fotografijes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        file = c.String(nullable: false),
                        HotelSobaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Photos");
            CreateIndex("dbo.Fotografijes", "HotelSobaId");
            AddForeignKey("dbo.Fotografijes", "HotelSobaId", "dbo.HotelSobas", "Id", cascadeDelete: true);
        }
    }
}
