namespace PatientApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameColumnIdInPhysicians : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Physician", name: "Id", newName: "PhysicianId");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Physician", name: "PhysicianId", newName: "Id");
        }
    }
}
