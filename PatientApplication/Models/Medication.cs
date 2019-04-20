using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PatientApplication.Models
{
    public class Medication
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        [Required]
        [StringLength(255)]
        public string MedicationName { get; set; }

        public string MedicationStrength { get; set; }

        public string MedicationDosage { get; set; }

        //Navigation Property for Many-To-One relationship with Patient
        public virtual Patient Patient { get; set; }


    }
}