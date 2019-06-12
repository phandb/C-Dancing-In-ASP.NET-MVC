using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PatientApplication.Models
{
    public class Physician
    {
        //Constructor
        public Physician()
        {
            this.Patients = new HashSet<Patient>();
        }

        [Column("PhysicianId")]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Physician Name")]
        public string PhysicianName { get; set; }

        [Display(Name = "Phone")]
        public string PhysicianPhone { get; set; }

        [Display(Name = "Address")]
        public string PhysicianAddress { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Specialty")]
        public string PhysicianSpecialty { get; set; }

        //Navigation Property for many-to-many relationship with Patient
        public virtual ICollection<Patient> Patients { get; set; }

    }
}