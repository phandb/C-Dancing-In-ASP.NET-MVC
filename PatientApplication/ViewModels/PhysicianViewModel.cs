using PatientApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientApplication.ViewModels
{
    public class PhysicianViewModel
    {
        public Physician Physician { get; set; }
        public Patient Patient { get; set; }
        
    }
}