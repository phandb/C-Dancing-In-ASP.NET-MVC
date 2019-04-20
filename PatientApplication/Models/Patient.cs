using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PatientApplication.Models
{
    public class Patient
    {
        //Call constructor
        public Patient()
        {
            this.Pharmacies = new HashSet<Pharmacy>();
            this.Physcians = new HashSet<Physician>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string Gender { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? Birthdate { get; set; }

        public string Address { get; set; }

        //Navigation property for Many-To-Many relationship with Pharmacy
        public virtual ICollection<Pharmacy> Pharmacies { get; set; }

        //Navigation property for Many-To-Many relationship with Physician
       public virtual ICollection<Physician> Physcians { get; set; }

        //Navigation property for One-To-Many relationship with Medication
        public virtual ICollection<Medication> Medications { get; set; }


    }
}