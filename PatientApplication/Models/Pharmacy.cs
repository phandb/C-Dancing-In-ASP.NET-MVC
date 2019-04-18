using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PatientApplication.Models
{
    public class Pharmacy
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string PharmacyName { get; set; }

        public string PharmacyPhone { get; set; }

        public string PharmacyAddress { get; set; }
    }
}