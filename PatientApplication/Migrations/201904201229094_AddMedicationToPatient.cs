namespace PatientApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMedicationToPatient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Medications", "PatientId", c => c.Int(nullable: false));
            CreateIndex("dbo.Medications", "PatientId");
            AddForeignKey("dbo.Medications", "PatientId", "dbo.Patients", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medications", "PatientId", "dbo.Patients");
            DropIndex("dbo.Medications", new[] { "PatientId" });
            DropColumn("dbo.Medications", "PatientId");
        }
    }
}
