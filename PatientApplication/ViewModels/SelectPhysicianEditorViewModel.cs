using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PatientApplication.Models;
using System.Web.Mvc;

namespace PatientApplication.ViewModels
{
    public class SelectPhysicianEditorViewModel
    {
        

        public Patient Patient { get; set; }

        //this property will hold all available physicians for selection
        public int physicianId { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public string Address { get; set; }
        public int patientId { get; set; }
        

        //selected checboxes
        public bool Selected { get; set; }

        

        
    }
}