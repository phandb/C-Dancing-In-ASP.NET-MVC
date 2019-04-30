using PatientApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientApplication.ViewModels
{
    public class MedicationFormViewModel
    {
        public Patient Patient { get; set; }
        public Medication Medication { get; set; }
    }
}