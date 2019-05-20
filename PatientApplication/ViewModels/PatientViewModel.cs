using PatientApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientApplication.ViewModels
{
    public class PatientViewModel
    {
        public Patient Patient { get; set; }

        //public Physician Physician { get; set; }

        //public Pharmacy Pharmacy { get; set; }

        public List<Physician> Physicians { get; set; }

        public List<Pharmacy> Pharmacies { get; set; }

       /* public string Title
        {
            get
            {
                return Id != 0 ? "Edit Patient" : "New Patient";
            }

        }*/
    }
}