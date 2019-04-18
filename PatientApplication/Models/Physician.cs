using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PatientApplication.Models
{
    public class Physician
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string PhysicianName { get; set; }

        public string PhysicianPhone { get; set; }

        public string PhysicianAddress { get; set; }

        [Required]
        [StringLength(255)]
        public string PhysicianSpecialty { get; set; }

    }
}