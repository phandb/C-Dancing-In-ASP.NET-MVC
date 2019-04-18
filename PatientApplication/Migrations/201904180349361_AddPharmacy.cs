namespace PatientApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPharmacy : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pharmacies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PharmacyName = c.String(nullable: false, maxLength: 255),
                        PharmacyPhone = c.String(),
                        PharmacyAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pharmacies");
        }
    }
}
