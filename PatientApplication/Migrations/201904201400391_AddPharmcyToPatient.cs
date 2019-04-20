namespace PatientApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPharmcyToPatient : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PharmacyPatients",
                c => new
                    {
                        Pharmacy_Id = c.Int(nullable: false),
                        Patient_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Pharmacy_Id, t.Patient_Id })
                .ForeignKey("dbo.Pharmacies", t => t.Pharmacy_Id, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.Patient_Id, cascadeDelete: true)
                .Index(t => t.Pharmacy_Id)
                .Index(t => t.Patient_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PharmacyPatients", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.PharmacyPatients", "Pharmacy_Id", "dbo.Pharmacies");
            DropIndex("dbo.PharmacyPatients", new[] { "Patient_Id" });
            DropIndex("dbo.PharmacyPatients", new[] { "Pharmacy_Id" });
            DropTable("dbo.PharmacyPatients");
        }
    }
}
