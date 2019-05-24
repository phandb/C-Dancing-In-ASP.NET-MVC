namespace PatientApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameColumnIdInMedications : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Medication", name: "Id", newName: "MedicationId");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Medication", name: "MedicationId", newName: "Id");
        }
    }
}
