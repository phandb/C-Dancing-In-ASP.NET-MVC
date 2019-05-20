using PatientApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientApplication.ViewModels
{
    public class PharmacyViewModel
    {
        public Pharmacy Pharmacy { get; set; }
        public Patient Patient { get; set; }

    }
}