namespace PatientApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhysicianToPatient : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PhysicianPatients",
                c => new
                    {
                        Physician_Id = c.Int(nullable: false),
                        Patient_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Physician_Id, t.Patient_Id })
                .ForeignKey("dbo.Physicians", t => t.Physician_Id, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.Patient_Id, cascadeDelete: true)
                .Index(t => t.Physician_Id)
                .Index(t => t.Patient_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhysicianPatients", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.PhysicianPatients", "Physician_Id", "dbo.Physicians");
            DropIndex("dbo.PhysicianPatients", new[] { "Patient_Id" });
            DropIndex("dbo.PhysicianPatients", new[] { "Physician_Id" });
            DropTable("dbo.PhysicianPatients");
        }
    }
}
