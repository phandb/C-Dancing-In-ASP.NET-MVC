namespace PatientApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatePhysicians : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Physicians (PhysicianName, PhysicianPhone, PhysicianAddress, PhysicianSpecialty) VALUES ('Eric Leong', '512-244-9024', '940 Hesters Crossing Road Round Rock, TX 78681', 'Family Medicine')");
            Sql("INSERT INTO Physicians (PhysicianName, PhysicianPhone, PhysicianAddress, PhysicianSpecialty) VALUES ('William Stassen', '512-244-9024', '940 Hesters Crossing Road Round Rock, TX 78681', 'Gastroenterology')");
            Sql("INSERT INTO Physicians (PhysicianName, PhysicianPhone, PhysicianAddress, PhysicianSpecialty) VALUES ('Cathy Little', '512-244-9024', '940 Hesters Crossing Road Round Rock, TX 78681', 'Pediatics')");
            Sql("INSERT INTO Physicians (PhysicianName, PhysicianPhone, PhysicianAddress, PhysicianSpecialty) VALUES ('Joe Nguyen', '512-244-9024', '940 Hesters Crossing Road Round Rock, TX 78681', 'Family Medicine')");
        }

        
        public override void Down()
        {
        }
    }
}
