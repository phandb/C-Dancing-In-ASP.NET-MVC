using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PatientApplication.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public  DbSet<Patient> Patients { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<Physician> Physicians { get; set; }
        

       public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //overriding pluralize convention
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //configure many to many relationship between patient and physician
            modelBuilder.Entity<Patient>().HasMany<Physician>(phy => phy.Physicians).WithMany(p => p.Patients)
                .Map(m =>
                {
                    m.MapLeftKey("PatientId");  //Patient Id
                    m.MapRightKey("PhysicianId");  //Physician Id
                    m.ToTable("PatientPhysicianMap");

                });

            
                


            base.OnModelCreating(modelBuilder);
        }

        public class ApplicationInitializer: System.Data.Entity.DropCreateDatabaseIfModelChanges<ApplicationDbContext>{

        }
    }
}