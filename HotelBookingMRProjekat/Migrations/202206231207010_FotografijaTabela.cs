namespace HotelBookingMRProjekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FotografijaTabela : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fotografijes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        file = c.String(nullable: false),
                        HotelSobaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HotelSobas", t => t.HotelSobaId, cascadeDelete: true)
                .Index(t => t.HotelSobaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fotografijes", "HotelSobaId", "dbo.HotelSobas");
            DropIndex("dbo.Fotografijes", new[] { "HotelSobaId" });
            DropTable("dbo.Fotografijes");
        }
    }
}
