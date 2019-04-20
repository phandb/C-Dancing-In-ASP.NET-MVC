using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PatientApplication.Models
{
    public class Pharmacy
    {
        //Constructor
        public Pharmacy()
        {
            //this.Patients = new HashSet<Patient>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string PharmacyName { get; set; }

        public string PharmacyPhone { get; set; }

        public string PharmacyAddress { get; set; }

        //Navigation property for many-to-many relationship with Patient
       // public virtual ICollection<Patient> Patients { get; set; }
    }
}