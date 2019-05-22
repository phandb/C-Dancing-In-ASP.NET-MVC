using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PatientApplication.Models;

namespace PatientApplication.ViewModels
{
    public class AssignedPhysicianData
    {
       
        public Patient Patient { get; set; }


        public List<Physician> Physicians { get; set; }
    }
}