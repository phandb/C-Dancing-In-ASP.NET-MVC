using PatientApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientApplication.ViewModels
{
    //this class defines what to be published to view only
    public class SelectPharmacyEditorViewModel
    {

        public Patient Patient { get; set; }

        public int patientId { get; set; }

        public int pharmacyId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        //selected checkboxed
        public bool Selected { get; set; }
         
    }
}