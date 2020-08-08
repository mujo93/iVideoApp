namespace iVideo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingPaymentPropertyToRental : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "Payment", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rentals", "Payment");
        }
    }
}
