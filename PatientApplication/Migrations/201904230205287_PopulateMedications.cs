namespace PatientApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMedications : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Medications ( PatientId, MedicationName, MedicationStrength, MedicationDosage ) VALUES (1,'Tylenol', '1000 mg', '2 tablets every 8 hours')");
            Sql("INSERT INTO Medications ( PatientId, MedicationName, MedicationStrength, MedicationDosage ) VALUES (1,'Advil', '1000 mg', '2 tablets every 8 hours')");
            Sql("INSERT INTO Medications ( PatientId, MedicationName, MedicationStrength, MedicationDosage ) VALUES (2,'Tylenol', '1000 mg', '2 tablets every 8 hours')");
            Sql("INSERT INTO Medications ( PatientId, MedicationName, MedicationStrength, MedicationDosage ) VALUES (2,'Motrin', '1000 mg', '2 tablets every 8 hours')");
            Sql("INSERT INTO Medications ( PatientId, MedicationName, MedicationStrength, MedicationDosage ) VALUES (2,'Motrin', '1000 mg', '2 tablets every 8 hours')");
        }
        
        public override void Down()
        {
        }
    }
}
