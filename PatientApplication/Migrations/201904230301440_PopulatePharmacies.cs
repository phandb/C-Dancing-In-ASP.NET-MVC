namespace PatientApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatePharmacies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Pharmacies (PharmacyName, PharmacyPhone, PharmacyAddress) VALUES ('Walmart at FM 685', '(512) 252-0112', '1548 Farm to Market 685, Pflugerville, TX 78660')");
            Sql("INSERT INTO Pharmacies (PharmacyName, PharmacyPhone, PharmacyAddress) VALUES ('Walmart at Palm Valley', '(512) 252-0112', '1548 Farm to Market 685, Pflugerville, TX 78660')");
            Sql("INSERT INTO Pharmacies (PharmacyName, PharmacyPhone, PharmacyAddress) VALUES ('WalGreens at Pflugervill Parkway', '(512) 252-0112', '1548 Farm to Market 685, Pflugerville, TX 78660')");
        }
        
        public override void Down()
        {
        }
    }
}
