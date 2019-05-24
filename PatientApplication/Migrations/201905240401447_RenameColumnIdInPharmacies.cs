namespace PatientApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameColumnIdInPharmacies : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Pharmacy", name: "Id", newName: "PharmacyId");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Pharmacy", name: "PharmacyId", newName: "Id");
        }
    }
}
