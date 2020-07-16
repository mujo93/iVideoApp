namespace iVideo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes(Id,Name, SignUpFee,DurationInMonths,DiscountRate) Values (1,'Pay As You Go',0,0,0)");
            Sql("INSERT INTO MembershipTypes(Id,Name, SignUpFee,DurationInMonths,DiscountRate) Values (2,'Monthly',30,1,10)");
            Sql("INSERT INTO MembershipTypes(Id,Name, SignUpFee,DurationInMonths,DiscountRate) Values (3,'Quarterly',90,3,15)");
            Sql("INSERT INTO MembershipTypes(Id,Name, SignUpFee,DurationInMonths,DiscountRate) Values (4,'Yearly',300,12,20)");
        }
        
        public override void Down()
        {
        }
    }
}
