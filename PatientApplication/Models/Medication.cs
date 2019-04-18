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

        [Required]
        [StringLength(255)]
        public string MedicationName { get; set; }

        public string MedicationStrength { get; set; }

        public string MedicationDosage { get; set; }

    }
}