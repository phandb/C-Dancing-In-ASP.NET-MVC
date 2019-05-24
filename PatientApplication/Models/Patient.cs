using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PatientApplication.Models
{
    public class Patient
    {
        //Call constructor
        public Patient()
        {
            this.Medications = new HashSet<Medication>();
            this.Pharmacies = new HashSet<Pharmacy>();
            this.Physicians = new HashSet<Physician>();
        }

        [Column("PatientId")]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string Gender { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Birthdate { get; set; }

        public string Address { get; set; }

        //Navigation property for Many-To-Many relationship with Pharmacy
        public virtual ICollection<Pharmacy> Pharmacies { get; set; }

        //Navigation property for Many-To-Many relationship with Physician
        public virtual ICollection<Physician> Physicians { get; set; }

        //Navigation property for One-To-Many relationship with Medication
        public virtual ICollection<Medication> Medications { get; set; }


    }
}