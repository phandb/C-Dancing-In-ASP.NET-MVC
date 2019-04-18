namespace PatientApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMedication : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MedicationName = c.String(nullable: false, maxLength: 255),
                        MedicationStrength = c.String(),
                        MedicationDosage = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Medications");
        }
    }
}
