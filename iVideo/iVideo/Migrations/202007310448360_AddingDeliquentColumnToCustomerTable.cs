namespace iVideo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingDeliquentColumnToCustomerTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsDeliquent", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsDeliquent");
        }
    }
}
