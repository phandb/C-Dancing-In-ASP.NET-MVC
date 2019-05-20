using PatientApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientApplication.ViewModels
{
    public class MedicationViewModel
    {
        public Patient Patient { get; set; }
        public Medication Medication { get; set; }
    }
}