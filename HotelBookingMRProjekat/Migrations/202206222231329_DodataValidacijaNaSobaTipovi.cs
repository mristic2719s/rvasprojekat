namespace HotelBookingMRProjekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodataValidacijaNaSobaTipovi : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HotelTipSobas", "NazivTipaSobe", c => c.String(nullable: false));
            AlterColumn("dbo.HotelTipSobas", "PansionTipaSobe", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HotelTipSobas", "PansionTipaSobe", c => c.String());
            AlterColumn("dbo.HotelTipSobas", "NazivTipaSobe", c => c.String());
        }
    }
}
