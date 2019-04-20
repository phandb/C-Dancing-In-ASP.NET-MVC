using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PatientApplication.Models
{
    public class Physician
    {
        //Constructor
        public Physician()
        {
            //this.Patients = new HashSet<Patient>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string PhysicianName { get; set; }

        public string PhysicianPhone { get; set; }

        public string PhysicianAddress { get; set; }

        [Required]
        [StringLength(255)]
        public string PhysicianSpecialty { get; set; }

        //Navigation Property for many-to-many relationship with Patient
        //public virtual ICollection<Patient> Patients { get; set; }

    }
}