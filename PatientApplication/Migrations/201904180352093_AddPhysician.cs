namespace PatientApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhysician : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Physicians",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhysicianName = c.String(nullable: false, maxLength: 255),
                        PhysicianPhone = c.String(),
                        PhysicianAddress = c.String(),
                        PhysicianSpecialty = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Physicians");
        }
    }
}
